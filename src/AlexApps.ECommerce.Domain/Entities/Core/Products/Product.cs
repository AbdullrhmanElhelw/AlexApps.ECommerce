using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.OrderItems;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;

namespace AlexApps.ECommerce.Domain.Entities.Core.Products;

public sealed class Product : BaseEntity
{
    private readonly IReadOnlyCollection<OrderItem> _items;

    private Product()
    {
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public decimal? VatRate { get; private set; }

    public int Quantity { get; private set; }

    public int StoreId { get; private set; }
    public Store Store { get; private set; }

    public int CartItemId { get; private set; }
    public CartItem CartItem { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _items;
}