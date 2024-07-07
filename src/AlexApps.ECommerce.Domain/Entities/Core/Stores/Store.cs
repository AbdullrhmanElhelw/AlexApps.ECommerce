using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Identity.Merchants;

namespace AlexApps.ECommerce.Domain.Entities.Core.Stores;

public sealed class Store : BaseEntity
{
    private readonly IReadOnlyCollection<Product> _products;

    private Store()
    {
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }

    public int MerchantId { get; private set; }
    public Merchant Merchant { get; private set; }

    public IReadOnlyCollection<Product> Products => _products;

    public static Store Create(string name, string? description, int merchantId)
    {
        return new Store
        {
            Name = name,
            Description = description,
            MerchantId = merchantId
        };
    }

    public static Store GetStore(int id, string name, string? description, int merchantId)
    {
        return new Store
        {
            Id = id,
            Name = name,
            Description = description,
            MerchantId = merchantId
        };
    }

    public static Store GetStoreName(int id, string name)
    {
        return new Store
        {
            Id = id,
            Name = name
        };
    }
}