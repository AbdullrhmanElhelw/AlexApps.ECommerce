namespace AlexApps.ECommerce.WebApi.Infrastructure;

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
    }

    public static class Customer
    {
        public const string Base = "api/customer";
        public const string RegisterCustomer = "register";
    }
}