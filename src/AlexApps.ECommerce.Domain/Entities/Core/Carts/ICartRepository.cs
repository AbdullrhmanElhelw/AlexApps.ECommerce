﻿namespace AlexApps.ECommerce.Domain.Entities.Core.Carts;

public interface ICartRepository
{
    Task<Cart?> GetById(int id);

    void Create(Cart cart);
}