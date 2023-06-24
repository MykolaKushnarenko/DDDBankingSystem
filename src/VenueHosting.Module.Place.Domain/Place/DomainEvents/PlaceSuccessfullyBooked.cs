
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Domain.Place.DomainEvents;

public sealed record PlaceSuccessfullyBooked(Guid PlaceId) : IntegrationEvent;