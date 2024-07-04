namespace AlexApps.ECommerce.Contracts.Authentication.Jwt;

public interface IJwtProvider
{
    Task<TokenResponse> GenerateTokenAsync(int userId, string email, string role, CancellationToken cancellationToken = default);
}