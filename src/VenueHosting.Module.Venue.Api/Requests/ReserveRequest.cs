namespace VenueHosting.Module.Venue.Api.Requests;

public class ReserveRequest
{
    public string? AttendeeId { get; set; }

    public string? BillId { get; set; }

    public int Amount { get; set; }

    public DateTime ReservationDateTime { get; set; }
}