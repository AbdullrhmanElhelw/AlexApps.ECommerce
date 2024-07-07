using AlexApps.ECommerce.Contracts.CQRS.Queries;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using FluentResults;

namespace AlexApps.ECommerce.Application.Carts.GetTotalPrice;

public sealed class GetTotalPriceQueryHandler : IQueryHandler<GetTotalPriceQuery, GetTotalPriceResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;

    public GetTotalPriceQueryHandler(ICartItemRepository cartItemRepository, ICartRepository cartRepository)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
    }

    public async Task<Result<GetTotalPriceResponse>> Handle(GetTotalPriceQuery request, CancellationToken cancellationToken)
    {
        var checkCartIsExists = await _cartRepository.GetByCustomerIdAsync(request.CustomerId);

        if (checkCartIsExists is null)
            return Result.Fail<GetTotalPriceResponse>("Cart not found");

        var totalPrice = await _cartItemRepository.GetTotalPrice(checkCartIsExists.Id);

        return Result.Ok(new GetTotalPriceResponse(totalPrice));
    }
}