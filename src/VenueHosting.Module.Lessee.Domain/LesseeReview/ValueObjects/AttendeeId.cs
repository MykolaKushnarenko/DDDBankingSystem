using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Lessee.Domain.LesseeReview.ValueObjects;

public sealed class AttendeeId : ValueObject
{
    public Guid Value { get; private set; }

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