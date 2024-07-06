using AlexApps.ECommerce.Application.Carts.AddItemToCart;
using AlexApps.ECommerce.Application.Carts.CreateCart;
using AlexApps.ECommerce.Application.Carts.GetCartItems;
using AlexApps.ECommerce.Application.Carts.GetCartPrice;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Cart.Base)]
[ApiController]
public class CartController : ApiBaseController
{
    public CartController(ISender sender) : base(sender)
    {
    }

    [HttpGet(ApiRoutes.Cart.GetCartItems)]
    public async Task<IActionResult> GetCartItems(int id)
    {
        var query = new GetCartItemsQuery(id);
        var result = await _sender.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoutes.Cart.CreateCart)]
    public async Task<IActionResult> CreateCart(int userId)
    {
        var command = new CreateCardCommand(userId);
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }

    [HttpPost(ApiRoutes.Cart.AddItemToCart)]
    public async Task<IActionResult> AddItemToCart(int cartId, int productId, int quantity)
    {
        var command = new AddItemToCartCommand(cartId, productId, quantity);
        var result = await _sender.Send(command);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }

    [HttpGet(ApiRoutes.Cart.GetCartTotalPrice)]
    public async Task<IActionResult> GetCartTotalPrice(int id)
    {
        var query = new GetCartTotalPriceQuery(id);
        var result = await _sender.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }
}