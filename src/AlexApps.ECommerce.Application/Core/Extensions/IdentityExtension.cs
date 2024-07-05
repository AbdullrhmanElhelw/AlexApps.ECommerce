using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Application.Core.Extensions;

internal static class IdentityExtension
{
    public static List<string> GetErrors(this IdentityResult result)
    {
        return result.Errors.Select(x => x.Description).ToList();
    }
}