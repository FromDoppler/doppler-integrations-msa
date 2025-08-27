using System.Security.Claims;
using System.Text.Json.Serialization;
using DopplerIntegrationsCore;
using DopplerIntegrationsData;
using DopplerIntegrationsDomain;
using DopplerIntegrationsMsa.DopplerSecurity;
using DopplerIntegrationsMsa.Logging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// It is if you want to override the configuration in your
// local environment, `*.Secret.*` files will not be
// included in git.
builder.Configuration.AddJsonFile("appsettings.Secret.json",
    optional: true,
    reloadOnChange: true);

// It is to override configuration using Docker's services.
// Probably this will be the way of overriding the
// configuration in our Swarm stack.
builder.Configuration.AddJsonFile("/run/secrets/appsettings.Secret.json",
    optional: true,
    reloadOnChange: true);

// It is to override configuration using a different file
// for each configuration entry. For example, you can create
// the file `/run/secrets/Logging__LogLevel__Default` with
// the content `Trace`. See:
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#key-per-file-configuration-provider
builder.Configuration.AddKeyPerFile("/run/secrets",
    optional: true,
    reloadOnChange: true);

builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
{
    loggerConfiguration.SetupSeriLog(hostContext.Configuration, hostContext.HostingEnvironment);
});

builder.Services.Configure<DopplerDataBaseSettings>(builder.Configuration.GetSection(DopplerDataBaseSettings.DopplerDataBase));

builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    o.SerializerOptions.WriteIndented = true;
    o.SerializerOptions.IncludeFields = true;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDopplerSecurity();

builder.Services.AddSingleton<IThirdPartyAppService, ThirdPartyAppService>();
builder.Services.AddSingleton<IThirdPartyAppXUserRepository, ThirdPartyAppXUserRepository>();
builder.Services.AddSingleton<IAssistedShoppingService, AssistedShoppingService>();
builder.Services.AddSingleton<IAssistedShoppingRepository, AssistedShoppingRepository>();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter the token into field as 'Bearer {token}'",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme },
                },
                Array.Empty<string>()
            }
        });
});
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policy => policy
.SetIsOriginAllowed(isOriginAllowed: _ => true)
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials());

app.UseHttpsRedirection();

app.MapGet("/user/connections", async Task<Results<Ok<IList<ThirdPartyAppXUser>>, NoContent>> (
    ClaimsPrincipal user, IThirdPartyAppService thirdPartyAppService) =>
{
    var idUser = SecurityUtils.GetAuthenticatedUserId(user);

    var response = await thirdPartyAppService.GetListThirdPartyAppByUser(idUser);

    return response.Any() ?
        TypedResults.Ok(response)
        : TypedResults.NoContent();
})
.WithName("UserConnections")
.WithOpenApi()
.RequireAuthorization(Policies.Default);

app.MapGet("/user/assisted-shopping/{idThirdPartyApp}/{dateFrom}/{dateTo}", async Task<Results<Ok<IList<AssistedShopping>>, NoContent>> (
    int idThirdPartyApp, DateTime dateFrom, DateTime dateTo, ClaimsPrincipal user, IAssistedShoppingService assistedShoppingService) =>
{
    var idUser = SecurityUtils.GetAuthenticatedUserId(user);

    var response = await assistedShoppingService.GetListAssistedShoppingByUser(idUser, idThirdPartyApp, dateFrom, dateTo);

    return response.Any() ?
        TypedResults.Ok(response)
        : TypedResults.NoContent();
})
.WithName("AssistedShopping")
.WithOpenApi()
.RequireAuthorization(Policies.Default);

app.MapGet("/integration/{idThirdPartyApp:int}/status",
    async Task<Results<Ok<RfmModel>, NotFound, NoContent>> (
        int idThirdPartyApp,
        ClaimsPrincipal user,
        IThirdPartyAppService thirdPartyAppService) =>
    {
        var idUser = SecurityUtils.GetAuthenticatedUserId(user);

        var thirdPartyAppXUser = await thirdPartyAppService
            .GetThirdPartyAppXUser(idUser, idThirdPartyApp);

        if (thirdPartyAppXUser is null)
        {
            return TypedResults.NotFound();
        }

        var rfmModel = await thirdPartyAppService
            .GetRfmModel(thirdPartyAppXUser);

        return rfmModel is null
            ? TypedResults.NoContent()
            : TypedResults.Ok(rfmModel);
    })
    .WithName("GetIntegrationStatus")
    .WithOpenApi()
    .RequireAuthorization(Policies.Default);

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }
