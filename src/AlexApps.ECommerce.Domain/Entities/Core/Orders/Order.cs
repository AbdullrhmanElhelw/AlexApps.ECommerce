using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.OrderItems;
using AlexApps.ECommerce.Domain.Entities.Identity.Buyers;
using AlexApps.ECommerce.Domain.Enums;

namespace AlexApps.ECommerce.Domain.Entities.Core.Orders;

public sealed class Order : BaseEntity
{
    private readonly IReadOnlyCollection<OrderItem> _orderItems;

    private Order()
    {
    }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }
}