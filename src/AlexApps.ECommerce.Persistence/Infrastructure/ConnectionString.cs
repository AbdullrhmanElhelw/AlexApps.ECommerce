namespace AlexApps.ECommerce.Persistence.Infrastructure;

public sealed class ConnectionString(string value)
{
    public const string SettingsKey = "DefaultConnection";
    public string Value { get; } = value;

    public static implicit operator string(ConnectionString connectionString)
    {
        return connectionString.Value;
    }
}