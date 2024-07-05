using AlexApps.ECommerce.Contracts.CQRS.Commands;

namespace AlexApps.ECommerce.Application.Merchants.Registration;

public sealed record RegisterMerchantCommand
    (
    string FirstName,
    string LastName,
    string City,
    string? Street,
    string Email,
    string Password) : ICommand;