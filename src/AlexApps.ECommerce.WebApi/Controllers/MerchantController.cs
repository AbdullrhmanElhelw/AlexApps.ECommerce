using AlexApps.ECommerce.Application.Merchants.Registration;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Merchants.Base)]
[ApiController]
public class MerchantController : ApiBaseController
{
    public MerchantController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Merchants.RegisterMerchant)]
    public async Task<IActionResult> RegisterMerchant([FromBody] RegisterMerchantCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}