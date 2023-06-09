using ITResume.Shared.Enums;
using System.Security.Claims;

namespace ITResume.Client.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal claims)
        => claims.FindFirstValue(ClaimTypes.NameIdentifier);
}
