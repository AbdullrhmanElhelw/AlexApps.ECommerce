using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using FluentResults;

namespace AlexApps.ECommerce.Application.Products.CreateProduct;

public sealed class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IStoreRepository storeRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _storeRepository = storeRepository;
    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var checkStoreIsExists = await _storeRepository.IsExistsAsync(request.StoreId);

        if (!checkStoreIsExists)
            return new Result().WithError(new RecordNotFoundError($"Store with this Id #{request.StoreId} Not Found"));

        var product = Product.Create(request.Name, request.Description, request.Price, request.VatRate, request.StockQuantity, request.StoreId);

        _productRepository.Insert(product);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail("An error occurred while saving the product.")
            : Result.Ok();
    }
}