namespace VenueHosting.Domain.Venue.ValueObjects;

public record ActivityId(Guid Value)
{
    public static ActivityId CreateUnique()
    {
        return new ActivityId(Guid.NewGuid());
    }

    public static ActivityId Create(Guid value)
    {
        return new ActivityId(value);

    }
}