using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Domain.Venue.DomainEvents;

public record VenueOrganizedDomainEvent(Guid VenueId, Guid LesseeId) : IDomainEvent;