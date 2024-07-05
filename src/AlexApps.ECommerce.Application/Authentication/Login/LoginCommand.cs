using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.Authentication;
using AlexApps.ECommerce.Contracts.Authentication.Jwt;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Domain.Common;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Application.Authentication.Login;

public sealed record LoginCommand
    (string Email, string Password) : ICommand<TokenResponse>;

public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, TokenResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkUserIsExists is null)
            return new Result().WithError(new RecordNotFoundError($"User with this email {request.Email} not found"));

        var checkPassword = await _userManager.CheckPasswordAsync(checkUserIsExists, request.Password);

        if (!checkPassword)
            return new Result().WithError(new PasswordNotCorrectError());

        var roles = await _userManager.GetRolesAsync(checkUserIsExists);

        var token = await _jwtProvider.GenerateTokenAsync(checkUserIsExists.Id,
                                                          checkUserIsExists.Email,
                                                          roles.FirstOrDefault().ToString(),
                                                          cancellationToken);

        return token;
    }
}