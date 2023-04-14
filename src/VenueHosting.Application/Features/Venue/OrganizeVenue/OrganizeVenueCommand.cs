using MediatR;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Features.Venue.OrganizeVenue;

public record OrganizeVenueCommand(
    OwnerId ownerId,
    LesseeId lesseeId,
    PlaceId placeId,
    string eventName,
    string description,
    bool isPublic,
    DateTime startAtDateTime,
    DateTime endAtDateTime) : IRequest<Domain.Venue.Venue>;