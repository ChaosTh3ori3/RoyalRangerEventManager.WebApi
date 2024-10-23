namespace RangerEventManager.Persistence.Settings;

public class IAMSettings
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string TokenEndpoint { get; set; }
    public string UsersEndpoint { get; set; }
}