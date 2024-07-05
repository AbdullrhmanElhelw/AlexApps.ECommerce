using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using FluentResults;

namespace AlexApps.ECommerce.Application.Stores.CreateStore;

public sealed class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand>
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoreCommandHandler(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
    {
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
    {
        var store = Store.Create(request.Name, request.Description, request.MerchantId);
        _storeRepository.Insert(store);
        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail("Failed To Save Store")
            : Result.Ok();
    }
}