using FluentResults;

namespace AlexApps.ECommerce.WebApi.Contracts;

public class ApiErrorResponse
{
    public IEnumerable<ApiError> Errors { get; }

    public ApiErrorResponse(Result result)
    {
        Errors = result.Errors.Select(e => new ApiError(e.Message));
    }
}

public class ApiError
{
    public string Message { get; }

    public ApiError(string message)
    {
        Message = message;
    }
}