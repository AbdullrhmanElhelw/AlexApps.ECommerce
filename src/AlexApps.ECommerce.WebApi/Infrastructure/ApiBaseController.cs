using AlexApps.ECommerce.Application.Core.Errors;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlexApps.ECommerce.WebApi.Infrastructure;

[Route("api/[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiBaseController(ISender sender)
    {
        _sender = sender;
    }

    protected IActionResult HandleFailure(Result result)
    {
        if (result.HasError<RecordNotFoundError>())
        {
            var errors = result.Errors.Select(error => new { message = error.Message }).ToArray();
            return NotFound(CreateProblemDetails("Not Found", 404, "The requested resource was not found.", errors));
        }
        if (result.HasError<ValidationError>())
        {
            var errors = result.Errors.Select(error => new { message = error.Message }).ToArray();
            return BadRequest(CreateProblemDetails("Validation Error", 400, "One or more validation errors occurred.", errors));
        }

        if (result.HasError<RecordIsAlreadyExists>())
        {
            var errors = result.Errors.Select(error => new { message = error.Message }).ToArray();
            return Conflict(CreateProblemDetails("Record Is Already Exists", 409, "The requested resource is already exists.", errors));
        }

        if (result.HasError<PasswordNotCorrectError>())
        {
            var errors = result.Errors.Select(error => new { message = error.Message }).ToArray();
            return Unauthorized(CreateProblemDetails("Unauthorized", 401, "Invalid Credentials", errors));
        }

        var defaultErrors = result.Errors.Select(error => new { message = error.Message }).ToArray();

        return BadRequest(CreateProblemDetails("Bad Request", 400, "One or more errors occurred.", defaultErrors));
    }

    protected IActionResult HandleSuccess(string message) =>
        Ok(CreateSuccessResponse(message));

    protected IActionResult HandleSuccess(string message, object data) =>
        Ok(CreateSuccessResponse(message, data));

    protected IActionResult HandleSuccess(object data) =>
        Ok(CreateSuccessResponse(data));

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        string detail,
        object[]? errors = null) =>
        new()
        {
            Title = title,
            Status = status,
            Detail = detail,
            Extensions =
            {
                    ["errors"] = errors
            }
        };

    private static object CreateSuccessResponse(string message) =>
        new
        {
            status = 200,
            message
        };

    private static object CreateSuccessResponse(string message, object data) =>
           new
           {
               status = 200,
               message,
               data
           };

    private static object CreateSuccessResponse(object data) =>
        new
        {
            status = 200,
            data
        };
}