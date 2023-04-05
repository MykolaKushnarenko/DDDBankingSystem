namespace VenueHosting.Domain.VenueDomain.Place.ValueObjects;

public record PlaceId(Guid Value)
{
    public static PlaceId CreateUnique()
    {
        return new PlaceId(Guid.NewGuid());
    }
}