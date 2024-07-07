using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using Microsoft.EntityFrameworkCore;

namespace AlexApps.ECommerce.Persistence.Repositories;

public class CartItemRepository : ICartItemRepository
{
    private readonly ECommerceDbContext _dbContext;

    public CartItemRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(CartItem cartItem) =>
        _dbContext.CartItems.Add(cartItem);

    public async Task<IReadOnlyCollection<CartItem>> GetAll(int cartId)
    {
        var cartItemData = await _dbContext.CartItems
            .Include(c => c.Product)
            .Where(c => c.CartId == cartId)
            .Select(c => new
            {
                c.Id,
                c.Product
            })
            .ToListAsync();

        return cartItemData.Select(c => CartItem.GetCartItem(c.Id, c.Product)).ToList();
    }

    public async Task<CartItem?> GetById(int id) =>
        await _dbContext.CartItems.FindAsync(id);

    public async Task<int> GetItemQuantity(int cartId, int productId) =>
        await _dbContext.CartItems
        .CountAsync(c => c.CartId == cartId && c.ProductId == productId);

    public async Task<decimal> GetTotalPrice(int cartId)
    {
        var totalPrice = await _dbContext.CartItems
            .Where(c => c.CartId == cartId)
            .Select(c => c.Product)
            .Select(c => new { c.Price, c.VatRate })
            .SumAsync(c => c.Price * (1 + (c.VatRate > 0 ? c.VatRate : 0)));

        return totalPrice.Value;
    }
}