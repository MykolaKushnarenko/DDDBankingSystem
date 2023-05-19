using VenueHosting.Module.Venue.Domain.Reservation.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;
using ReservationId = VenueHosting.Module.Venue.Domain.Reservation.ValueObjects.ReservationId;

namespace VenueHosting.Module.Venue.Domain.Reservation;

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