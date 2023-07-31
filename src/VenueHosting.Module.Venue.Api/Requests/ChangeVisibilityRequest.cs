using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Api.Requests;

public class ChangeVisibilityRequest
{
    public Visibility Visibility { get; init; }
}