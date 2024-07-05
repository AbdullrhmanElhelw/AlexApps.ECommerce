using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Application.Core.Extensions;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Domain.Entities.Identity.Buyers;
using AlexApps.ECommerce.Domain.Enums;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Application.Customers.Registration;

public sealed class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
{
    private readonly UserManager<Customer> _userManager;

    public async Task<Result> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkUserIsExists is not null)
            return new Result().WithError(new RecordIsAlreadyExists($"User with this email {request.Email} is Already Exists"));

        var customer = Customer.Create(request.FirstName, request.LastName, request.City, request.Email, request.Street);

        var createtionResult = await _userManager.CreateAsync(customer, request.Password);

        if (!createtionResult.Succeeded)
            return Result.Fail(createtionResult.GetErrors());

        var roleResult = await _userManager.AddToRoleAsync(customer, nameof(ApplicationRoles.Customer));

        if (!roleResult.Succeeded)
            return Result.Fail(roleResult.GetErrors());

        return Result.Ok();
    }
}