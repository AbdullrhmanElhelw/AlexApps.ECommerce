using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;

namespace AlexApps.ECommerce.Domain.Entities.Core.CartItems;

public sealed class CartItem : BaseEntity
{
    private CartItem()
    {
    }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    public int ProductId { get; private set; }
    public Product Product { get; private set; }

    public int CartId { get; private set; }
    public Cart Cart { get; private set; }

    public static CartItem Create(int cartId, int productId, int quantity, decimal price)
    {
        return new CartItem
        {
            CartId = cartId,
            ProductId = productId,
            Quantity = quantity,
            Price = price
        };
    }

    public static CartItem GetCartItem(int id, int quantity, decimal price, Product product)
    {
        return new CartItem
        {
            Id = id,
            Quantity = quantity,
            Price = price,
            Product = product
        };
    }
}