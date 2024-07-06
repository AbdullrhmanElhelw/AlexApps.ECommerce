using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using FluentResults;

namespace AlexApps.ECommerce.Application.Products.GetProduct;

public sealed class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<GetProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var checkProductIsExist = await _productRepository.IsExistsAsync(request.Id);

        if (!checkProductIsExist)
            return new Result().WithError(new RecordNotFoundError($"Product with this Id #{request.Id} Not Found"));

        var product = await _productRepository.GetAsync(request.Id);

        return Result.Ok(new GetProductDto(product.Id, product.Name, product.Description, product.Price, product.VatRate));
    }
}