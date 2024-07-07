using AlexApps.ECommerce.Contracts.CQRS.Commands;

namespace AlexApps.ECommerce.Application.Carts.CreateCart;

public sealed record CreateCardCommand
    (int UserId) : ICommand;