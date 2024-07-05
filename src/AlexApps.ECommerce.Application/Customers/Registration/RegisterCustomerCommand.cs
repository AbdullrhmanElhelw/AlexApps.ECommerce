using AlexApps.ECommerce.Contracts.CQRS.Commands;

namespace AlexApps.ECommerce.Application.Customers.Registration;

public sealed record RegisterCustomerCommand
    (string FirstName,
     string LastName,
     string Email,
     string City,
     string? Street,
     string Password) : ICommand;