using AlexApps.ECommerce.Application;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlexApps.ECommerce.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey)
                               ?? throw new ArgumentNullException(nameof(ConnectionString),
                                   "Connection String Not Found!!");

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<ECommerceDbContext>(op => { op.UseSqlServer(connectionString); });

        services.AddScoped<IECommerceDbContext>(sp =>
            sp.GetRequiredService<ECommerceDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ECommerceDbContext>());

        return services;
    }
}