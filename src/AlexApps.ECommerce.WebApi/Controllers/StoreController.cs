using AlexApps.ECommerce.Application.Core.Utilities;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(ApplicationRoles.Merchant))]
public class StoreController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public StoreController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    /*
        [HttpPost(ApiRoutes.Store.CreateStore)]
        public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreCommand request)
        {
            var userId = _userUtility.GetUserId();
            var result = await _sender.Send(request);
            return result.IsSuccess ?
                Ok(result) :
                HandleFailure(result.ToResult());
        }*/
}