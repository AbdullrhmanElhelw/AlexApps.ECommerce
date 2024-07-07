using AlexApps.ECommerce.Application.Customers.Registration;
using AlexApps.ECommerce.WebApi.Contracts;
using AlexApps.ECommerce.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Controllers;

[Route(ApiRoutes.Customer.Base)]
[ApiController]
public class CustomerController : ApiBaseController
{
    public CustomerController(ISender sender) : base(sender)
    {
    }

    [HttpPost(ApiRoutes.Customer.RegisterCustomer)]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerCommand command)
    {
        var result = await _sender.Send(command);
        return result.IsSuccess ?
             Ok(result) :
             HandleFailure(result);
    }
}