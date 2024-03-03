namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

public enum VenueStatus
{
    InPayment,
    OverDuePayment,

    Organized,
    Cancelled
}