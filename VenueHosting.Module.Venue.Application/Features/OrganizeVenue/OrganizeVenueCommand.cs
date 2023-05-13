using MediatR;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

public record OrganizeVenueCommand(
    OwnerId OwnerId,
    LesseeId LesseeId,
    PlaceId PlaceId,
    string EventName,
    string Description,
    bool IsPublic,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime) : IRequest<Domain.Venue.Venue>;