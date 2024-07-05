using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AlexApps.ECommerce.Application.Core.Utilities;

public class UserUtility
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserUtility(IHttpContextAccessor httpContextAccessor) => _httpContextAccessor = httpContextAccessor;

    public int GetUserId()
    {
        var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return Convert.ToInt32(userId);
    }
}