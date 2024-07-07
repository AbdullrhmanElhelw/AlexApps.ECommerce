using AlexApps.ECommerce.Application.Products.CreateProduct;
using AlexApps.ECommerce.Application.Products.GetProducts;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.WebApi.Contracts;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Product.Base)]
[ApiController]
public class ProductController : ApiBaseController
{
    public ProductController(ISender sender) : base(sender)
    {
    }

    [HttpGet(ApiRoutes.Product.GetProducts)]
    [HttpGet(ApiRoutes.Product.GetProduct)]
    public async Task<IActionResult> GetProduct(int storeId)
    {
        var result = await _sender.Send(new GetProductsQuery(storeId));

        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoutes.Product.CreateProduct)]
    [Authorize(Roles = nameof(ApplicationRoles.Merchant))]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}