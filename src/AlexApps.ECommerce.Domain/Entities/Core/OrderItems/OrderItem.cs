using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Orders;
using AlexApps.ECommerce.Domain.Entities.Core.Products;

namespace AlexApps.ECommerce.Domain.Entities.Core.OrderItems;

public sealed class OrderItem : BaseEntity
{
    private OrderItem()
    {
    }

    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public int ProductId { get; private set; }
    public Product Product { get; private set; }

    public int OrderId { get; private set; }
    public Order Order { get; private set; }
}