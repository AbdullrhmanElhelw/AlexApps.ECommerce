using AlexApps.ECommerce.Domain.Entities.Core.Products;
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

    public void Insert(Product product) =>
        _context.Products.Add(product);

    public async Task<bool> IsExistsAsync(int Id) =>
        await _context.Products.AnyAsync(x => x.Id == Id);
}