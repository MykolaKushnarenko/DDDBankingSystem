using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;
using ReservationId = VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects.ReservationId;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private Reservation() {}

    private Reservation(ReservationId id, UserId userId, BillId billId, int amount,
        DateTime reservationDateTime) : base(id)
    {
        UserId = userId;
        BillId = billId;
        Amount = amount;
        ReservationDateTime = reservationDateTime;
    }

    public UserId UserId { get; private set; }

    public BillId BillId { get; private set; }

    public int Amount { get; private set; }

    public DateTime ReservationDateTime { get; private set; }

    public static Reservation Create(UserId userId, BillId billId, int amount, DateTime reservationDateTime)
    {
        return new Reservation(ReservationId.CreateUnique(), userId, billId, amount,
            reservationDateTime);
    }
}