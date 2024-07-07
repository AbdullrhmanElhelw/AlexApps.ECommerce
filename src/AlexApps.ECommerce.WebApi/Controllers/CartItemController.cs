using AlexApps.ECommerce.Application.Cart_Items.AddItem;
using AlexApps.ECommerce.Application.Cart_Items.GetItemQuantity;
using AlexApps.ECommerce.Application.Core.Utilities;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.WebApi.Contracts;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.CartItem.Base)]
[ApiController]
public class CartItemController : ApiBaseController
{
    private readonly UserUtility _userUtility;

    public CartItemController(ISender sender, UserUtility userUtility) : base(sender)
    {
        _userUtility = userUtility;
    }

    [Authorize(Roles = nameof(ApplicationRoles.Customer))]
    [HttpPost(ApiRoutes.CartItem.AddItem)]
    public async Task<IActionResult> AddItem(int pId)
    {
        var getUserId = _userUtility.GetUserId();
        if (getUserId == 0)
            return Unauthorized();

        var command = new AddItemCommand(getUserId, pId);
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }

    [Authorize(Roles = nameof(ApplicationRoles.Customer))]
    [HttpGet(ApiRoutes.CartItem.GetItemQuantity)]
    public async Task<IActionResult> GetItemQuantity(int cId, int pId)
    {
        var query = new GetItemQuantityQuery(cId, pId);
        var result = await _sender.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }
}