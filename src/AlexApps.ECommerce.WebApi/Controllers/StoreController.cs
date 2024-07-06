using AlexApps.ECommerce.Application.Stores.CreateStore;
using AlexApps.ECommerce.Application.Stores.GetSotre;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Store.Base)]
[ApiController]
public class StoreController : ApiBaseController
{
    public StoreController(ISender sender) : base(sender)
    {
    }

    [HttpGet(ApiRoutes.Store.GetStore)]
    public async Task<IActionResult> GetStoreAsync([FromRoute] int id)
    {
        var result = await _sender.Send(new GetStoreQuery(id));
        return result.IsSuccess ?
            Ok(result.Value) :
            HandleFailure(result.ToResult());
    }

    [HttpPost(ApiRoutes.Store.CreateStore)]
    public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreCommand request)
    {
        var result = await _sender.Send(request);
        return result.IsSuccess ?
            Ok(result) :
            HandleFailure(result);
    }
}