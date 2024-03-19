using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;

public class Schedule : ValueObject
{
    internal Schedule(DateTimeOffset startTime, DateTimeOffset endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
    
    public DateTimeOffset StartTime { get; private set; }

    public DateTimeOffset EndTime { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartTime;
        yield return EndTime;
    }
}