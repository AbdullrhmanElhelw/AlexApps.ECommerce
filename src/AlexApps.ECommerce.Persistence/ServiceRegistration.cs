using AlexApps.ECommerce.Application;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using AlexApps.ECommerce.Domain.Entities.Identity.Buyers;
using AlexApps.ECommerce.Domain.Entities.Identity.Merchants;
using AlexApps.ECommerce.Persistence.Infrastructure;
using AlexApps.ECommerce.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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

    public static IServiceCollection AddIdentityUsers(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole<int>>(op =>
            {
                op.Password.RequireDigit = false;
                op.Password.RequireLowercase = false;
                op.Password.RequireUppercase = false;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ECommerceDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<Merchant>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<ECommerceDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<Customer>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<ECommerceDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }

    public static IServiceCollection AddRepositores(this IServiceCollection services)
    {
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        return services;
    }
}