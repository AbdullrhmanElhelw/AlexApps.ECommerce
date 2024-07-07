using AlexApps.ECommerce.Contracts.CQRS.Queries;

namespace AlexApps.ECommerce.Application.Carts.GetTotalPrice;

public sealed record GetTotalPriceQuery
    (int CustomerId) : IQuery<GetTotalPriceResponse>;

public sealed record GetTotalPriceResponse
    (decimal TotalPrice);