using FluentResults;

namespace AlexApps.ECommerce.Application.Core.Errors;

public sealed class PasswordNotCorrectError : Error
{
    public PasswordNotCorrectError() :
        base("Password is not correct")
    {
    }
}