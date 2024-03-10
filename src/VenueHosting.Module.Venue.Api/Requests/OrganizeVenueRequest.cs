using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Api.Requests;

public record OrganizeVenueRequest(
    Guid HostId,
    Guid PlaceId,
    string EventName,
    string Description,
    int Capacity,
    Visibility Visibility,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime);