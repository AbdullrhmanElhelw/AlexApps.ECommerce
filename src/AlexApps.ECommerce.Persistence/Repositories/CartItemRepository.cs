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
                c.Quantity,
                c.Price,
                c.Product
            })
            .ToListAsync();

        return cartItemData.Select(c => CartItem.GetCartItem(c.Id, c.Quantity, c.Price, c.Product)).ToList();
    }

    public async Task<CartItem?> GetById(int id) =>
        await _dbContext.CartItems.FindAsync(id);

    public async Task<decimal> GetTotalPrice(int cartId) =>
    await _dbContext.CartItems
        .Where(c => c.CartId == cartId)
        .Include(c => c.Product)
        .AsNoTracking()
        .Select(c => c.Quantity * c.Product.Price * (1 + (c.Product.VatRate ?? 0)))
        .SumAsync();
}