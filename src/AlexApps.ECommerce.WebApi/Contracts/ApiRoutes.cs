namespace AlexApps.ECommerce.WebApi.Contracts;

public static class ApiRoutes
{
    public static class Merchants
    {
        public const string Base = "api/merchant";
        public const string RegisterMerchant = "register";
    }

    public static class Authentication
    {
        public const string Base = "api/authentication";
        public const string Login = "login";
    }

    public static class Store
    {
        public const string Base = "api/store";
        public const string CreateStore = "create";
        public const string GetStore = "{id}";
        public const string GetStores = "stores";
    }

    public static class Customer
    {
        public const string Base = "api/customer";
        public const string RegisterCustomer = "register";
    }

    public static class Product
    {
        public const string Base = "api/product";
        public const string CreateProduct = "create";
        public const string GetProduct = "{id}";
        public const string GetProducts = "{storeId:int}";
    }

    public static class Cart
    {
        public const string Base = "api/cart";
        public const string CreateCart = "create";
        public const string AddItemToCart = "add";
        public const string GetCartItems = "items";
        public const string GetCartTotalPrice = "total-price";
    }

    public static class CartItem
    {
        public const string Base = "api/cart-item";
        public const string AddItem = "add/{pId:int}";
        public const string GetItemQuantity = "quantity/{cId:int}/{pId:int}";
    }
}