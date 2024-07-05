using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.OrderItems;
using AlexApps.ECommerce.Domain.Entities.Core.Orders;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace AlexApps.ECommerce.Application;

public interface IECommerceDbContext
{
    DbSet<Store> Stores { get; }
    DbSet<Product> Products { get; }
    DbSet<Order> Orrders { get; }

    DbSet<Cart> Carts { get; }

    DbSet<CartItem> CartItems { get; }

    DbSet<OrderItem> OrderItem { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}