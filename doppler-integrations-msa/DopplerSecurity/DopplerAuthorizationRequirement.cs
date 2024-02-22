using Microsoft.AspNetCore.Authorization;

namespace DopplerIntegrationsMsa.DopplerSecurity;

public class DopplerAuthorizationRequirement : IAuthorizationRequirement
{
    public bool AllowSuperUser { get; init; }
    public bool AllowOwnResource { get; init; }
}
