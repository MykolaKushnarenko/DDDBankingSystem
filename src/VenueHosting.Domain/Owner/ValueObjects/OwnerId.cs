namespace VenueHosting.Domain.VenueDomain.Owner.ValueObjects;

public record OwnerId(Guid Value)
{
    public static OwnerId CreateUnique()
    {
        return new OwnerId(Guid.NewGuid());
    }
}