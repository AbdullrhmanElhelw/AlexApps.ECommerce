using AlexApps.ECommerce.Contracts.CQRS.Commands;

namespace AlexApps.ECommerce.Application.Carts.AddItemToCart;

public sealed record AddItemToCartCommand
    (int CartId,
     int ProductId,
     int Quantity) : ICommand;