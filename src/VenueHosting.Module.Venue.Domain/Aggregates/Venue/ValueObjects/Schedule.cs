using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

public class Schedule : ValueObject
{
    public DateTimeOffset StartTime { get; set; }

    public DateTimeOffset EndTime { get; set; }

    public bool IsBooked { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartTime;
        yield return EndTime;
        yield return IsBooked;
    }
}