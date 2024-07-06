﻿namespace AlexApps.ECommerce.Domain.Entities.Core.CartItems;

public interface ICartItemRepository
{
    Task<decimal> GetTotalPrice(int cartId);

    Task<CartItem?> GetById(int id);

    Task<IReadOnlyCollection<CartItem>> GetAll(int cartId);

    void Create(CartItem cartItem);
}