namespace VenueHosting.Module.User.Infrastructure.Configuration;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);

    public string Secret { get; init; } = null!;

    public int ExpiryDurationMinutes { get; init; }

    public string Issuer { get; init; } = null!;

    public string Audience { get; init; } = null!;
}