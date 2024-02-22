using Microsoft.IdentityModel.Tokens;

namespace DopplerIntegrationsMsa.DopplerSecurity;

public class DopplerSecurityOptions
{
    public IEnumerable<SecurityKey> SigningKeys { get; set; } = System.Array.Empty<SecurityKey>();
}
