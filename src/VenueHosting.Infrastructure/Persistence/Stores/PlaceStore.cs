using Microsoft.EntityFrameworkCore;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Place;
using VenueHosting.Infrastructure.Persistence.Specification;

namespace VenueHosting.Infrastructure.Persistence.Stores;

internal sealed class PlaceStore : IPlaceStore
{
    private readonly VenueHostingDbContext _dbContext;

    public PlaceStore(VenueHostingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Place>> FetchAllAsync(CancellationToken token)
    {
        //TODO: That's critical, add with cursor paging.
        return await _dbContext.Places.ToListAsync(token);
    }
    

    public async Task AddAsync(Place place, CancellationToken token)
    {

        await _dbContext.Places.AddAsync(place, token);
    }

    public async Task<IReadOnlyList<Place>> FetchAllBySpecificationAsync(ISpecification<Place> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Place>.GetQuery(_dbContext.Places, specification).ToListAsync(token);
    }
}