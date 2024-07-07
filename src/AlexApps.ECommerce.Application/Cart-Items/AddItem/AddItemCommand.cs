using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Products;
using FluentResults;

namespace AlexApps.ECommerce.Application.Cart_Items.AddItem;

public sealed record AddItemCommand
    (
     int CustomerId,
     int ProductId) : ICommand;

public sealed class AddItemCommandHandler : ICommandHandler<AddItemCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public AddItemCommandHandler(ICartItemRepository cartItemRepository,
                                 IUnitOfWork unitOfWork,
                                 ICartRepository cartRepository,
                                 IProductRepository productRepository)
    {
        _cartItemRepository = cartItemRepository;
        _unitOfWork = unitOfWork;
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var checkCartIsExists = await _cartRepository.GetByCustomerIdAsync(request.CustomerId);

        if (checkCartIsExists is null)
            return new Result().WithError(new RecordNotFoundError("Cart not found"));

        var checkProductIsExists = await _productRepository.IsExistsAsync(request.ProductId);

        if (!checkProductIsExists)
            return new Result().WithError(new RecordNotFoundError("Product not found"));

        var cartItem = CartItem.Create(checkCartIsExists.Id, request.ProductId);

        _cartItemRepository.Create(cartItem);
        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0 ?
            Result.Fail("Failed to add item to cart") :
            Result.Ok();
    }
}