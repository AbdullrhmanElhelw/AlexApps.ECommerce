using FluentResults;

namespace AlexApps.ECommerce.Application.Core.Errors;

public sealed class RecordNotFoundError : Error
{
    public RecordNotFoundError(string message) : base(message)
    {
    }
}