

using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Contracts.Events;

public record VenueCreatedIntegrationEvent(Guid VenueId, Guid LesseeId) : IntegrationEvent;