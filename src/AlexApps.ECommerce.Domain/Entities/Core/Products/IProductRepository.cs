namespace AlexApps.ECommerce.Domain.Entities.Core.Products;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetProductsByStoreIdAsync(int storeId);

    Task<Product?> GetAsync(int Id);

    Task<bool> IsExistsAsync(int Id);

    void Insert(Product product);
}