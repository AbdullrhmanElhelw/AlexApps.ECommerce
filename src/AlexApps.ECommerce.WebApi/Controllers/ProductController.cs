using AlexApps.ECommerce.Application.Products.CreateProduct;
using AlexApps.ECommerce.Application.Products.GetProduct;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Product.Base)]
[ApiController]
public class ProductController : ApiBaseController
{
    public ProductController(ISender sender) : base(sender)
    {
    }

    [HttpGet(ApiRoutes.Product.GetProduct)]
    public async Task<IActionResult> GetProduct(int id)
    {
        var result = await _sender.Send(new GetProductQuery(id));

        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoutes.Product.CreateProduct)]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}