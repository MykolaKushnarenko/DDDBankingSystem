using Component.Domain.DomainEvents;

namespace VenueHosting.Contracts.Events;

public record VenueCreatedDomainEvent(Guid VenueId, int Capacity) : IDomainEvent;