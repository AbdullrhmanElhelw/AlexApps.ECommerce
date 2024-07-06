namespace AlexApps.ECommerce.Domain.Entities.Core.Stores;

public interface IStoreRepository
{
    Task<bool> IsExistsAsync(int id);

    Task<Store?> GetAsync(int id);

    void Insert(Store store);
}