using AlexApps.ECommerce.Domain.Entities.Core.Carts;

namespace AlexApps.ECommerce.Persistence.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ECommerceDbContext _dbContext;

    public CartRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(Cart cart)
        => _dbContext.Carts.Add(cart);

    public async Task<Cart?> GetById(int id)
        => await _dbContext.Carts.FindAsync(id);
}