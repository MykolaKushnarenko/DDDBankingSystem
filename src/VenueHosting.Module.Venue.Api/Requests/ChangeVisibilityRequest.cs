
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;

namespace VenueHosting.Module.Venue.Api.Requests;

public class ChangeVisibilityRequest
{
    public Visibility Visibility { get; init; }
}