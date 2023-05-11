using VenueHosting.Domain.Common.DomainEvents;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Domain.Place.DomainEvents;

public sealed record PlaceSuccessfullyBooked(PlaceId PlaceId) : IDomainEvent;