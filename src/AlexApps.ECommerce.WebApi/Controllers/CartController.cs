using AlexApps.ECommerce.Application.Carts.CreateCart;
using AlexApps.ECommerce.Application.Carts.GetCartItems;
using AlexApps.ECommerce.Application.Carts.GetTotalPrice;
using AlexApps.ECommerce.Application.Core.Utilities;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.WebApi.Contracts;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Cart.Base)]
[ApiController]
public class CartController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public CartController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    [HttpPost(ApiRoutes.Cart.CreateCart)]
    [Authorize(Roles = nameof(ApplicationRoles.Customer))]
    public async Task<IActionResult> CreateCart()
    {
        var getUserId = _userUtility.GetUserId();
        if (getUserId == 0)
            return Unauthorized();

        var command = new CreateCardCommand(getUserId);
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Cart.GetCartItems)]
    [Authorize(Roles = nameof(ApplicationRoles.Customer))]
    public async Task<IActionResult> GetCartItems()
    {
        var getUserId = _userUtility.GetUserId();
        if (getUserId == 0)
            return Unauthorized();

        var query = new GetCartItemsQuery(getUserId);
        var result = await _sender.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpGet(ApiRoutes.Cart.GetCartTotalPrice)]
    [Authorize(Roles = nameof(ApplicationRoles.Customer))]
    public async Task<IActionResult> GetCartTotalPrice()
    {
        var getUserId = _userUtility.GetUserId();
        if (getUserId == 0)
            return Unauthorized();
        var query = new GetTotalPriceQuery(getUserId);

        var result = await _sender.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }
}