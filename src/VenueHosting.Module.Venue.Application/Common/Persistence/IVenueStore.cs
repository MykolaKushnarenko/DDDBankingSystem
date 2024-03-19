using Component.Domain.Models;
using Component.Persistence.SqlServer.Storages;

namespace VenueHosting.Module.Venue.Application.Common.Persistence;

public interface IVenueStore : IStorageSpecification<Domain.Aggregates.VenueAggregate.Venue>
{
    Task<Domain.Aggregates.VenueAggregate.Venue?> FetchVenueByIdAsync(Id<Domain.Aggregates.VenueAggregate.Venue> venueId, CancellationToken token);

    Task AddAsync(Domain.Aggregates.VenueAggregate.Venue venue);
}