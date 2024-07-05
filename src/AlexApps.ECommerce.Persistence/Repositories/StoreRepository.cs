using AlexApps.ECommerce.Domain.Entities.Core.Stores;

namespace AlexApps.ECommerce.Persistence.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ECommerceDbContext _dbContext;

    public StoreRepository(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Insert(Store store) =>
        _dbContext.Stores.Add(store);
}