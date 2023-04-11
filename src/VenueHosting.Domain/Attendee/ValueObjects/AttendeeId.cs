using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.Attendee.ValueObjects;

public sealed class AttendeeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private AttendeeId(){}

    private AttendeeId(Guid value)
    {
        Value = value;
    }

    public static AttendeeId CreateUnique()
    {
        return new AttendeeId(Guid.NewGuid());
    }

    public static AttendeeId Create(Guid value)
    {
        return new AttendeeId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}