using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using FluentResults;

namespace AlexApps.ECommerce.Application.Carts.GetCartPrice;

public sealed record GetCartTotalPriceQuery
    (int CartId) : IQuery<GetTotalPriceDto>;

public sealed record GetTotalPriceDto(decimal TotalPrice);

public sealed class GetCartTotalPriceQueryHandler : IQueryHandler<GetCartTotalPriceQuery, GetTotalPriceDto>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;

    public GetCartTotalPriceQueryHandler(ICartItemRepository cartItemRepository, ICartRepository cartRepository)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Result<GetTotalPriceDto>> Handle(GetCartTotalPriceQuery request, CancellationToken cancellationToken)
    {
        var checkCartIsExists = await _cartRepository.GetById(request.CartId);
        if (checkCartIsExists == null)
            return new Result().WithError(new RecordNotFoundError("Cart Not Found"));

        var totalPrice = await _cartItemRepository.GetTotalPrice(request.CartId);

        return Result.Ok(new GetTotalPriceDto(totalPrice));
    }
}