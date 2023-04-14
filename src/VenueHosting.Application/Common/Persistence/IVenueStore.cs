using VenueHosting.Domain.Venue;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Common.Persistence;

public interface IVenueStore : IStorageSpecification<Venue>
{
    Task<Venue?> FetchVenueByIdAsync(VenueId venueId);

    Task AddAsync(Venue venue);
}