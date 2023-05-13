namespace VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

public enum VenueStatus
{
    InPayment,
    OverDuePayment,

    Organized,
    Cancelled
}