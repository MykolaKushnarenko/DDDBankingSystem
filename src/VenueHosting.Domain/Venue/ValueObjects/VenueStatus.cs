namespace VenueHosting.Domain.Venue.ValueObjects;

public enum VenueStatus
{
    InPayment,
    OverDuePayment,

    Organized,
    Cancelled
}