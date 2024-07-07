using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using Microsoft.EntityFrameworkCore;

namespace AlexApps.ECommerce.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDbContext _context;

    public ProductRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetAsync(int Id) =>
        await _context.Products.FindAsync(Id);

    public async Task<IReadOnlyCollection<Product>> GetProductsByStoreIdAsync(int storeId) =>
        await _context.Products
        .Where(x => x.StoreId == storeId)
        .Include(x => x.Store)
        .Select(x => Product.GetProduct(
            x.Id,
            x.Name,
            x.Description,
            x.Price,
            x.VatRate,
            x.Quantity,
            Store.GetStoreName(x.Store.Id, x.Store.Name)))
        .ToListAsync();

    public void Insert(Product product) =>
        _context.Products.Add(product);

    public async Task<bool> IsExistsAsync(int Id) =>
        await _context.Products.AnyAsync(x => x.Id == Id);
}