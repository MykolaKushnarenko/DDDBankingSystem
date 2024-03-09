using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Place.Domain.Place.DomainEvents;

public sealed record PlaceSuccessfullyBooked(Guid PlaceId) : IDomainEvent;