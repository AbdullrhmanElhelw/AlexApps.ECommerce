using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using FluentResults;

namespace AlexApps.ECommerce.Application.Carts.GetCartItems;

public sealed record GetCartItemsQuery
    (int cartId) : IQuery<IReadOnlyCollection<CartItemDto>>;

public sealed record CartItemDto
    (int Id,
    int Quantity,
    decimal Price,
    string ProductName);

public sealed class GetCartItemsQueryHandler :
    IQueryHandler<GetCartItemsQuery, IReadOnlyCollection<CartItemDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;

    public GetCartItemsQueryHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<Result<IReadOnlyCollection<CartItemDto>>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
    {
        var checkCartIsExsits = await _cartRepository.GetById(request.cartId);
        if (checkCartIsExsits is null)
            return new Result<IReadOnlyCollection<CartItemDto>>().WithError(new RecordNotFoundError("Cart Not Found"));

        var cartItems = await _cartItemRepository.GetAll(request.cartId);

        IReadOnlyCollection<CartItemDto> cartItemDtos = cartItems.Select(ci => new CartItemDto(ci.Id,
                                                                                               ci.Quantity,
                                                                                               ci.Price,
                                                                                               ci.Product.Name)).ToList();

        return Result.Ok(cartItemDtos);
    }
}