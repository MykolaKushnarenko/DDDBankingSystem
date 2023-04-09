namespace VenueHosting.Domain.Lessee.ValueObjects;

public sealed record LesseeId(Guid Value)
{
    public static LesseeId CreateUnique()
    {
        return new LesseeId(Guid.NewGuid());
    }

    public static LesseeId Create(Guid value)
    {
        return new LesseeId(value);
    }
}