using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Application.Products.GetProduct;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;
using FluentResults;

namespace AlexApps.ECommerce.Application.Products.GetProducts;

public sealed class GetProductsQueryHandler :
    IQueryHandler<GetProductsQuery, IReadOnlyCollection<GetProductDto>>
{
    private readonly IStoreRepository _storeRepository;
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IStoreRepository storeRepository, IProductRepository productRepository)
    {
        _storeRepository = storeRepository;
        _productRepository = productRepository;
    }

    public async Task<Result<IReadOnlyCollection<GetProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var checkStoreIsExists = await _storeRepository.GetAsync(request.storeId);

        if (checkStoreIsExists is null)
            return new Result().WithError(new RecordNotFoundError("Store not found"));

        var products = await _productRepository.GetProductsByStoreIdAsync(request.storeId);

        IReadOnlyCollection<GetProductDto> productDtos =
            products.Select(x => new GetProductDto(
                x.Id,
                x.Name,
                x.Description,
                x.Price,
                x.VatRate)).ToList();

        return Result.Ok(productDtos);
    }
}