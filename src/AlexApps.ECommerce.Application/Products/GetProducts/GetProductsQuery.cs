using AlexApps.ECommerce.Application.Products.GetProduct;
using AlexApps.ECommerce.Contracts.CQRS.Queries;

namespace AlexApps.ECommerce.Application.Products.GetProducts;

public sealed record GetProductsQuery
    (int storeId) : IQuery<IReadOnlyCollection<GetProductDto>>;