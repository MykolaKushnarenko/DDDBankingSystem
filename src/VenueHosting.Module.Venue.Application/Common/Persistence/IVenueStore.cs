using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Persistence.Storages;

namespace VenueHosting.Module.Venue.Application.Common.Persistence;

public interface IVenueStore : IStorageSpecification<Domain.Venue.Venue>
{
    Task<Domain.Venue.Venue?> FetchVenueByIdAsync(VenueId venueId);

    Task AddAsync(Domain.Venue.Venue venue);
}