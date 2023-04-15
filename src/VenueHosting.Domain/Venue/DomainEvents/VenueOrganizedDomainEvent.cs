using VenueHosting.Domain.Common.DomainEvents;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.Venue.DomainEvents;

public record VenueOrganizedDomainEvent(VenueId VenueId, PlaceId PlaceId, LesseeId LesseeId) : IDomainEvent;