using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Application.Common.Specifications;
using VenueHosting.SharedKernel.Persistence.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

internal sealed class PlaceStore : IPlaceStore
{
    private readonly VenueApplicationDbContext _dbContext;

    public PlaceStore(VenueApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification,
        CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Place.Place>.GetQuery(_dbContext.Places, specification).AnyAsync(token);
    }

    public async Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync(CancellationToken token)
    {
        //TODO: That's critical, add with cursor paging.
        return await _dbContext.Places.ToListAsync(token);
    }


    public async Task AddAsync(Domain.Place.Place place, CancellationToken token)
    {

        await _dbContext.Places.AddAsync(place, token);
    }

    public Task UpdateAsync(Domain.Place.Place place)
    {
        _dbContext.Places.Update(place);

        return Task.CompletedTask;
    }

    public async Task<Domain.Place.Place?> FetchBySpecification(ISpecification<Domain.Place.Place> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Place.Place>.GetQuery(_dbContext.Places, specification).FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<Domain.Place.Place>> FetchAllBySpecificationAsync(ISpecification<Domain.Place.Place> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<Domain.Place.Place>.GetQuery(_dbContext.Places, specification).ToListAsync(token);
    }
}