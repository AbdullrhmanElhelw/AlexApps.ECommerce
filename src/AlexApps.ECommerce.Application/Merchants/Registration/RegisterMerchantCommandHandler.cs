using AlexApps.ECommerce.Application.Core.Extensions;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Domain.Entities.Identity.Merchants;
using AlexApps.ECommerce.Domain.Enums;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Application.Merchants.Registration;

public sealed class RegisterMerchantCommandHandler : ICommandHandler<RegisterMerchantCommand>
{
    private readonly UserManager<Merchant> _userManager;

    public RegisterMerchantCommandHandler(UserManager<Merchant> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> Handle(RegisterMerchantCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkUserIsExists is not null)
            return Result.Fail("User with this email already exists");

        var marchant = Merchant.Create(request.FirstName, request.LastName, request.City, request.Email);

        var createtionResult = await _userManager.CreateAsync(marchant, request.Password);

        if (!createtionResult.Succeeded)
            return Result.Fail(createtionResult.GetErrors());

        var roleResult = await _userManager.AddToRoleAsync(marchant, nameof(ApplicationRoles.Merchant));

        if (!roleResult.Succeeded)
            return Result.Fail(roleResult.GetErrors());

        return Result.Ok();
    }
}
