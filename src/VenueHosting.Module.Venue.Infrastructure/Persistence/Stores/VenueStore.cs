using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;
using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Application.Common.Persistence;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

internal sealed class VenueStore : IVenueStore
{
    private readonly VenueApplicationDbContext _dbContext;

    public VenueStore(VenueApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Domain.Aggregates.Venue.Venue?> FetchVenueByIdAsync(Id<Domain.Aggregates.Venue.Venue> venueId,
        CancellationToken token)
    {
        return _dbContext.Venues.Where(x => x.Id == venueId).SingleOrDefaultAsync(token);
    }

    public async Task AddAsync(Domain.Aggregates.Venue.Venue venue)
    {
        await _dbContext.Venues.AddAsync(venue);
    }

    public async Task<Domain.Aggregates.Venue.Venue?> FetchBySpecification(
        ISpecification<Domain.Aggregates.Venue.Venue> specification,
        CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Aggregates.Venue.Venue>
            .GetQuery(_dbContext.Venues, specification)
            .FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<Domain.Aggregates.Venue.Venue>> FetchAllBySpecificationAsync(
        ISpecification<Domain.Aggregates.Venue.Venue> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Aggregates.Venue.Venue>
            .GetQuery(_dbContext.Venues, specification)
            .ToListAsync(token);
    }
}