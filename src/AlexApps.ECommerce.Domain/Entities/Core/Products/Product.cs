﻿using AlexApps.ECommerce.Domain.Common;
using AlexApps.ECommerce.Domain.Entities.Core.CartItems;
using AlexApps.ECommerce.Domain.Entities.Core.OrderItems;
using AlexApps.ECommerce.Domain.Entities.Core.Stores;

namespace AlexApps.ECommerce.Domain.Entities.Core.Products;

public sealed class Product : BaseEntity
{
    private readonly IReadOnlyCollection<OrderItem> _items;
    private readonly List<CartItem> _cartItems;

    private Product()
    {
    }

    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public decimal? VatRate { get; private set; }

    public int Quantity { get; private set; }

    public int StoreId { get; private set; }
    public Store Store { get; private set; }

    public IReadOnlyCollection<CartItem> CartItems => _cartItems;

    public IReadOnlyCollection<OrderItem> OrderItems => _items;

    public static Product Create(string name, string? description, decimal price, decimal? vatRate, int quantity, int storeId)
    {
        return new Product
        {
            Name = name,
            Description = description,
            Price = price,
            VatRate = vatRate,
            Quantity = quantity,
            StoreId = storeId
        };
    }

    public static Product GetProduct(int id,
                                     string name,
                                     string? description,
                                     decimal price,
                                     decimal? vatRate,
                                     int quantity,
                                     Store store)
    {
        return new Product
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price,
            VatRate = vatRate,
            Quantity = quantity,
            Store = store
        };
    }

    public static bool HasVatRate(Product product)
    {
        return product.VatRate.HasValue;
    }
}