using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Identity.Buyers;

namespace AlexApps.ECommerce.Domain.Entities.Core.Carts;

public sealed class Cart : BaseEntity
{
    private readonly List<CartItem> _cartItems;

    private Cart()
    {
    }

    public int Quantity { get; private set; }

    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }

    public IReadOnlyCollection<CartItem> CartItems => _cartItems;

    public static Cart Create(int customerId)
    {
        return new Cart
        {
            CustomerId = customerId
        };
    }
}