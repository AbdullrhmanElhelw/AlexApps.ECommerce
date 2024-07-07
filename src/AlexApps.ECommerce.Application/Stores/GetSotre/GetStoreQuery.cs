using AlexApps.ECommerce.Contracts.CQRS.Queries;

namespace AlexApps.ECommerce.Application.Stores.GetSotre;

public sealed record GetStoreQuery
    (int Id) : IQuery<GetStoreDto>;

public sealed record GetStoreDto
    (int Id, string Name, string? Description, int MerchentId);