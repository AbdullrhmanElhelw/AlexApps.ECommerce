using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using FluentResults;

namespace AlexApps.ECommerce.Application.Carts.AddItemToCart;

public sealed class AddItemToCartCommandHandler
    : ICommandHandler<AddItemToCartCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddItemToCartCommandHandler(ICartRepository cartRepository,
                                       IUnitOfWork unitOfWork,
                                       IProductRepository productRepository,
                                       ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<Result> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetById(request.CartId);
        if (cart is null)
            return new Result().WithError(new RecordNotFoundError("Cart Not Found"));

        var product = await _productRepository.GetAsync(request.ProductId);

        if (product is null)
            return new Result().WithError(new RecordNotFoundError("Product Not Found"));

        var cartItem = CartItem.Create(request.CartId, request.ProductId, request.Quantity, product.Price);

        _cartItemRepository.Create(cartItem);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0 ?
             new Result().WithError("Error saving changes")
             : new Result();
    }
}