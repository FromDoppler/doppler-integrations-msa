using System.Security.Claims;

namespace DopplerIntegrationsMsa.DopplerSecurity;

public static class SecurityUtils
{
    public static int GetAuthenticatedUserId(ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(userIdClaim, out var id) ? id : 0;
    }
}
