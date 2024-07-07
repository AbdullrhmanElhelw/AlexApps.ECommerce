using AlexApps.ECommerce.Contracts.CQRS.Commands;

namespace AlexApps.ECommerce.Application.Stores.CreateStore;

public sealed record CreateStoreCommand
    (
    int MerchantId,
    string Name,
    string? Description) : ICommand;

public sealed record CreateStoreRequest
    (string Name,
    string? Description);