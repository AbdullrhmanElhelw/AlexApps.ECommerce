using FluentResults;

namespace AlexApps.ECommerce.Application.Core.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
    }

    public static ValidationError Create(Error[] errors)
    {
        var errorMessages = errors.Select(error => error.Message).ToArray();
        var message = string.Join(", ", errorMessages);
        return new ValidationError(message);
    }
}