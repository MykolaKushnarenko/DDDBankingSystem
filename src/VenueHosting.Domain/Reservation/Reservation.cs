using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Reservation.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.Reservation;

public sealed class Reservation : AggregateRote<ReservationId, Guid>
{
    private Reservation() {}

    private Reservation(ReservationId id, AttendeeId attendeeId, VenueId venueId, BillId billId, int amount,
        DateTime reservationDateTime) : base(id)
    {
        AttendeeId = attendeeId;
        VenueId = venueId;
        BillId = billId;
        Amount = amount;
        ReservationDateTime = reservationDateTime;
    }


    public AttendeeId AttendeeId { get; private set; }

    public VenueId VenueId { get; private set; }

    public BillId BillId { get; private set; }

    public int Amount { get; private set; }

    public DateTime ReservationDateTime { get; private set; }

    public static Reservation Create(AttendeeId attendeeId, VenueId venueId, BillId billId, int amount)
    {
        return new Reservation(ReservationId.CreateUnique(), attendeeId, venueId, billId, amount,
            DateTime.UtcNow);
    }

}