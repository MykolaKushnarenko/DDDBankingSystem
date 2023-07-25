using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;
using ReservationId = VenueHosting.Module.Venue.Domain.Venue.ValueObjects.ReservationId;

namespace VenueHosting.Module.Venue.Domain.Venue.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private Reservation() {}

    private Reservation(ReservationId id, AttendeeId attendeeId, BillId billId, int amount,
        DateTime reservationDateTime) : base(id)
    {
        AttendeeId = attendeeId;
        BillId = billId;
        Amount = amount;
        ReservationDateTime = reservationDateTime;
    }

    public AttendeeId AttendeeId { get; private set; }

    public BillId BillId { get; private set; }

    public int Amount { get; private set; }

    public DateTime ReservationDateTime { get; private set; }

    public static Reservation Create(AttendeeId attendeeId, BillId billId, int amount)
    {
        return new Reservation(ReservationId.CreateUnique(), attendeeId, billId, amount,
            DateTime.UtcNow);
    }
}