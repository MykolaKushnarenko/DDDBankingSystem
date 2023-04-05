namespace VenueHosting.Domain.Reservation.ValueObjects;

public sealed record ReservationId(Guid Value)
{
    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }
}