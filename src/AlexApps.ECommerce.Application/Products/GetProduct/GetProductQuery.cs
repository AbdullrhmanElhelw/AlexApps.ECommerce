using AlexApps.ECommerce.Contracts.CQRS.Queries;

namespace AlexApps.ECommerce.Application.Products.GetProduct;

public sealed record GetProductQuery
    (int Id) : IQuery<GetProductDto>;

public sealed record GetProductDto
    (int Id, string Name, string? Description, decimal Price, decimal? VatRate);