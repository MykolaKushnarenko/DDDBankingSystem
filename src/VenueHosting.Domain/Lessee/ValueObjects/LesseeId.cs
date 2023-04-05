namespace VenueHosting.Domain.VenueDomain.Lessee.ValueObjects;

public sealed record LesseeId(Guid Value)
{
    public static LesseeId CreateUnique()
    {
        return new LesseeId(Guid.NewGuid());
    }
}