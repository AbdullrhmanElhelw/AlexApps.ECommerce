using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AlexApps.ECommerce.Application.Core.Utilities;

public class UserUtility
    (IHttpContextAccessor httpContextAccessor)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public int GetUserId()
    {
        var claim = ClaimTypes.NameIdentifier;
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(claim);
        return userId is null ? 0 : int.Parse(userId);
    }
}