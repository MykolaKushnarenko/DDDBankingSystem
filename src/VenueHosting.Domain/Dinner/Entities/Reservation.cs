using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Guest.ValueObjects;

namespace VenueHosting.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    private Reservation(ReservationId id, int guestCount, string reservationStatus, GuestId guestId, BillId billId,
        DateTime arrivalDateTime, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public int GuestCount { get; private set; }
    
    public string ReservationStatus { get; private set; }
    
    public GuestId GuestId { get; private set; }
    
    public BillId BillId { get; private set; }
    
    public DateTime ArrivalDateTime { get; private set; }
    
    public DateTime CreatedDateTime { get; private set; }
    
    public DateTime UpdatedDateTime { get; private set; }

    public static Reservation Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId,
        DateTime arrivalDateTime)
    {
        return new Reservation(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId,
            arrivalDateTime, DateTime.UtcNow, DateTime.UtcNow);
    }
}