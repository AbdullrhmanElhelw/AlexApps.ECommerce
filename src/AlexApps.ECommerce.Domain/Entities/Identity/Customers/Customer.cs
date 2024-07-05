﻿using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Core.Orders;

namespace AlexApps.ECommerce.Domain.Entities.Identity.Buyers;

public sealed class Customer : ApplicationUser
{
    private readonly IReadOnlyCollection<Order> _orders;

    private Customer()
    {
    }

    public IReadOnlyCollection<Order> Orders => _orders;

    public int CartId { get; private set; }
    public Cart Cart { get; private set; }
}