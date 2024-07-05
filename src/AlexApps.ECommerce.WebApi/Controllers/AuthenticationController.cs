using AlexApps.ECommerce.Application.Authentication.Login;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Authentication.Base)]
[ApiController]
public class AuthenticationController : ApiBaseController
{
    public AuthenticationController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Authentication.Login)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommand request)
    {
        var result = await _sender.Send(request);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }
}