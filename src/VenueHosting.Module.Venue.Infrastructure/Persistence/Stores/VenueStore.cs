using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Persistence.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

internal sealed class VenueStore : IVenueStore
{
    private readonly VenueApplicationDbContext _dbContext;

    public VenueStore(VenueApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Domain.Venue.Venue?> FetchVenueByIdAsync(VenueId venueId)
    {
        return _dbContext.Venues.Where(x => x.Id == venueId).SingleOrDefaultAsync();
    }

    public async Task AddAsync(Domain.Venue.Venue venue)
    {
        await _dbContext.Venues.AddAsync(venue);
    }

    public async Task<Domain.Venue.Venue?> FetchBySpecification(ISpecification<Domain.Venue.Venue> specification,
        CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Venue.Venue>.GetQuery(_dbContext.Venues, specification)
            .FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<Domain.Venue.Venue>> FetchAllBySpecificationAsync(
        ISpecification<Domain.Venue.Venue> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Venue.Venue>.GetQuery(_dbContext.Venues, specification)
            .ToListAsync(token);
    }
}