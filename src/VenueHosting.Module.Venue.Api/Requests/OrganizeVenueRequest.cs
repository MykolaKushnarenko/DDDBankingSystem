using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Api.Requests;

public record OrganizeVenueRequest(
    string OwnerId,
    string LesseeId,
    string PlaceId,
    string EventName,
    string Description,
    Visibility Visibility,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime);