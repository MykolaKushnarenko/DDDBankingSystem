using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public Guid Value { get; }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}