using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

public record OrganizeVenueCommand(
    OwnerId OwnerId,
    LesseeId LesseeId,
    PlaceId PlaceId,
    string EventName,
    string Description,
    Visibility Visibility,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime) : IRequest<Domain.Aggregates.Venue.Venue>;