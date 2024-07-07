using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using FluentResults;

namespace AlexApps.ECommerce.Application.Stores.GetSotre;

public sealed class GetStoreQueryHandler
    : IQueryHandler<GetStoreQuery, GetStoreDto>
{
    private readonly IStoreRepository _storeRepository;

    public GetStoreQueryHandler(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Result<GetStoreDto>> Handle(GetStoreQuery request, CancellationToken cancellationToken)
    {
        var checkStoreIsExists = await _storeRepository.IsExistsAsync(request.Id);

        if (!checkStoreIsExists)
            return new Result().WithError(new RecordNotFoundError($"Store with this Id #{request.Id} Not Found"));

        var store = await _storeRepository.GetAsync(request.Id);

        return Result.Ok(new GetStoreDto(store.Id, store.Name, store.Description, store.MerchantId));
    }
}