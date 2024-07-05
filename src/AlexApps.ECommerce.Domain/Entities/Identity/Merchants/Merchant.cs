using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;

namespace AlexApps.ECommerce.Domain.Entities.Identity.Merchants;

public sealed class Merchant : ApplicationUser
{
    private readonly IReadOnlyCollection<Store> _store;

    private Merchant()
    {
    }

    public IReadOnlyCollection<Store> Store => _store;
}