namespace AlexApps.ECommerce.Contracts.Authentication.Settings;

public interface IJwtSettings
{
    const string SettingsKey = "Jwt";
    string Key { get; set; }
    string Issuer { get; set; }
    string Audience { get; set; }
    int ExpiryInMinutes { get; set; }
}