using FluentResults;

namespace AlexApps.ECommerce.Application.Core.Errors;

public sealed class RecordIsAlreadyExists : Error
{
    public RecordIsAlreadyExists(string message) : base(message)
    {
    }
}