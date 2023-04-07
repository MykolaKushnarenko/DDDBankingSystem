namespace VenueHosting.Domain.Venue.ValueObjects;

public sealed record VenueId(Guid Value)
{
    public static VenueId CreateUnique()
    {
        return new VenueId(Guid.NewGuid());
    }

    public static VenueId Create(Guid value)
    {
        return new VenueId(value);
    }
}