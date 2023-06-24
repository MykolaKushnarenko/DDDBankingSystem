
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;

public sealed class AttendeeId : ValueObject
{
    public Guid Value { get; }

    private AttendeeId(){}

    private AttendeeId(Guid value)
    {
        Value = value;
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