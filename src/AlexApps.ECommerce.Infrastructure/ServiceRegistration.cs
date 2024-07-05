using AlexApps.ECommerce.Contracts.Authentication.Jwt;
using AlexApps.ECommerce.Domain.Enums;
using AlexApps.ECommerce.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AlexApps.ECommerce.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));
        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }

    public static IServiceCollection AddAuthenticationSchema(this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddAuthentication(op =>
        {
            op.DefaultAuthenticateScheme = "Default";
            op.DefaultChallengeScheme = "Default";
        })
            .AddJwtBearer("Default", op =>
            {
                var settings = configuration.GetSection(JwtSettings.SettingsKey).Get<JwtSettings>();
                var readKey = Encoding.ASCII.GetBytes(settings.Key);
                var key = new SymmetricSecurityKey(readKey);
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    IssuerSigningKey = key
                };
            });

        return services;
    }

    public static IServiceCollection AddAuthorizationPolices(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(nameof(ApplicationRoles.Admin), policy => policy.RequireRole(nameof(ApplicationRoles.Admin)))
            .AddPolicy(nameof(ApplicationRoles.Merchant), policy => policy.RequireRole(nameof(ApplicationRoles.Merchant)))
            .AddPolicy(nameof(ApplicationRoles.Customer), policy => policy.RequireRole(nameof(ApplicationRoles.Customer)));

        return services;
    }
}