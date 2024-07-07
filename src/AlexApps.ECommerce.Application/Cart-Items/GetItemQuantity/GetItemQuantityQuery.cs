using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using FluentResults;

namespace AlexApps.ECommerce.Application.Cart_Items.GetItemQuantity;

public sealed record GetItemQuantityQuery
    (int CartId, int ProductId) : IQuery<int>;

public sealed class GetItemQuantityQueryHandler : IQueryHandler<GetItemQuantityQuery, int>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public GetItemQuantityQueryHandler(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IProductRepository productRepository)
    {
        _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task<Result<int>> Handle(GetItemQuantityQuery request, CancellationToken cancellationToken)
    {
        var checkCartIsExists = await _cartRepository.GetById(request.CartId);

        if (checkCartIsExists is null)
            return new Result().WithError(new RecordNotFoundError("Cart not found"));

        var checkProductIsExists = await _productRepository.IsExistsAsync(request.ProductId);

        if (!checkProductIsExists)
            return new Result().WithError(new RecordNotFoundError("Product not found"));

        var quantity = await _cartItemRepository.GetItemQuantity(request.CartId, request.ProductId);

        return Result.Ok(quantity);
    }
}