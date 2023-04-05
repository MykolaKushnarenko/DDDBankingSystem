namespace VenueHosting.Domain.Place.ValueObjects;

public record FacilityId(Guid Value)
{
    public static FacilityId CreateUnique()
    {
        return new FacilityId(Guid.NewGuid());
    }
}