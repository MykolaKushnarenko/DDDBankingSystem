namespace VenueHosting.Domain.VenueDomain.Place.ValueObjects;

public record PlaceId(Guid Value)
{
    public static PlaceId CreateUnique()
    {
        return new PlaceId(Guid.NewGuid());
    }

    public static PlaceId Create(Guid value)
    {
        return new PlaceId(value);
    }
}