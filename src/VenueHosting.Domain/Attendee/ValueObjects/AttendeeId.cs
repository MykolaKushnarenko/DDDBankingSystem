namespace VenueHosting.Domain.Attendee.ValueObjects;

public record AttendeeId(Guid Value)
{
    public static AttendeeId CreateUnique()
    {
        return new AttendeeId(Guid.NewGuid());
    }
}