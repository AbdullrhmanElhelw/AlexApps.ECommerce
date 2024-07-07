using AlexApps.ECommerce.Application.Core.Utilities;
using AlexApps.ECommerce.Application.Stores.CreateStore;
using AlexApps.ECommerce.Application.Stores.GetSotre;
using AlexApps.ECommerce.Application.Stores.GetStores;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.WebApi.Contracts;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Store.Base)]
[ApiController]
public class StoreController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public StoreController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    [HttpGet(ApiRoutes.Store.GetStore)]
    public async Task<IActionResult> GetStoreAsync([FromRoute] int id)
    {
        var result = await _sender.Send(new GetStoreQuery(id));
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpGet(ApiRoutes.Store.GetStores)]
    public async Task<IActionResult> GetStoresAsync()
    {
        var result = await _sender.Send(new GetStoresQuery());
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoutes.Store.CreateStore)]
    [Authorize(Roles = nameof(ApplicationRoles.Merchant))]
    public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreRequest request)
    {
        var getUserId = _userUtility.GetUserId();

        if (getUserId == 0)
            return Unauthorized();

        var command = new CreateStoreCommand(getUserId, request.Name, request.Description);

        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}