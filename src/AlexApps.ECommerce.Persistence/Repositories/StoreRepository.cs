using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace AlexApps.ECommerce.Persistence.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ECommerceDbContext _dbContext;

    public StoreRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Store?> GetAsync(int id) =>
          await _dbContext.Stores
        .FirstOrDefaultAsync(x => x.Id == id);

    public void Insert(Store store) =>
        _dbContext.Stores.Add(store);

    public async Task<bool> IsExistsAsync(int id) =>
         await _dbContext.Stores
        .AnyAsync(x => x.Id == id);
}