using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

public sealed class ReservationId : ValueObject
{
    public Guid Value { get; protected set; }

    private ReservationId()
    {
    }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
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