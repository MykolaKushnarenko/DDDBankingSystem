namespace VenueHosting.Domain.Venue.ValueObjects;

public sealed record VenueId(Guid Value)
{
    public static VenueId CreateUnique()
    {
        return new VenueId(Guid.NewGuid());
    }
}