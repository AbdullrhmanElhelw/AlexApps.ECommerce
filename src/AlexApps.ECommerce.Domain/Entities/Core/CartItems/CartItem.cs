using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;

namespace AlexApps.ECommerce.Domain.Entities.Core.CartItems;

public sealed class CartItem : BaseEntity
{
    private CartItem()
    {
    }

    public int ProductId { get; private set; }
    public Product Product { get; private set; }

    public int CartId { get; private set; }
    public Cart Cart { get; private set; }

    public static CartItem Create(int cartId, int productId)
    {
        return new CartItem
        {
            CartId = cartId,
            ProductId = productId,
        };
    }

    public static CartItem GetCartItem(int id, Product product)
    {
        return new CartItem
        {
            Id = id,
            Product = product
        };
    }
}