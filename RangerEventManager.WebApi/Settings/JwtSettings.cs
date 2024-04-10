namespace RangerEventManager.WebApi.Settings;

 public record class JwtSettings(
    string Issuer,
    string Audience,
    string SigningKey,
    int ExpirationSeconds
);
