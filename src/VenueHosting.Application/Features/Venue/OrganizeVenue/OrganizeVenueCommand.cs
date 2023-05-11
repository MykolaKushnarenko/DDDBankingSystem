using MediatR;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Features.Venue.OrganizeVenue;

public record OrganizeVenueCommand(
    OwnerId OwnerId,
    LesseeId LesseeId,
    PlaceId PlaceId,
    string EventName,
    string Description,
    bool IsPublic,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime) : IRequest<Domain.Venue.Venue>;