using AlexApps.ECommerce.Application.Stores.GetSotre;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using FluentResults;

namespace AlexApps.ECommerce.Application.Stores.GetStores;

public sealed record GetStoresQuery()
    : IQuery<IReadOnlyCollection<GetStoreDto>>;

public sealed class GetStoresQueryHandler : IQueryHandler<GetStoresQuery, IReadOnlyCollection<GetStoreDto>>
{
    private readonly IStoreRepository _storeRepository;

    public GetStoresQueryHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Result<IReadOnlyCollection<GetStoreDto>>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
    {
        var sotres = await _storeRepository.GetAllAsync();

        var result = sotres.Select(x => new GetStoreDto(x.Id, x.Name, x.Description, x.MerchantId)).ToList();

        return Result.Ok<IReadOnlyCollection<GetStoreDto>>(result);
    }
}