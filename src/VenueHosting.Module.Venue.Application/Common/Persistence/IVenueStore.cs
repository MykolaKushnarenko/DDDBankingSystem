using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Domain;
using VenueHosting.SharedKernel.Persistence.Storages;

namespace VenueHosting.Module.Venue.Application.Common.Persistence;

public interface IVenueStore : IStorageSpecification<Domain.Aggregates.Venue.Venue>
{
    Task<Domain.Aggregates.Venue.Venue?> FetchVenueByIdAsync(Id<Domain.Aggregates.Venue.Venue> venueId, CancellationToken token);

    Task AddAsync(Domain.Aggregates.Venue.Venue venue);
}