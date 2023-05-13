using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Place.Application.Common.Persistence;
using VenueHosting.Module.Place.Application.Common.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.Stores;

internal sealed class PlaceStore : IPlaceStore
{
    private readonly ApplicationDbContext _dbContext;

    public PlaceStore(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification,
        CancellationToken token)
    {
        return await SpecificationEvaluator<VenueHosting.Domain.Place.Place>.GetQuery(_dbContext.Places, specification).AnyAsync(token);
    }

    public async Task<IReadOnlyList<VenueHosting.Domain.Place.Place>> FetchAllAsync(CancellationToken token)
    {
        //TODO: That's critical, add with cursor paging.
        return await _dbContext.Places.ToListAsync(token);
    }


    public async Task AddAsync(VenueHosting.Domain.Place.Place place, CancellationToken token)
    {

        await _dbContext.Places.AddAsync(place, token);
    }

    public Task UpdateAsync(VenueHosting.Domain.Place.Place place)
    {
        _dbContext.Places.Update(place);

        return Task.CompletedTask;
    }

    public async Task<VenueHosting.Domain.Place.Place?> FetchBySpecification(ISpecification<VenueHosting.Domain.Place.Place> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<VenueHosting.Domain.Place.Place>.GetQuery(_dbContext.Places, specification).FirstOrDefaultAsync(token);
    }

    public async Task<IReadOnlyList<VenueHosting.Domain.Place.Place>> FetchAllBySpecificationAsync(ISpecification<VenueHosting.Domain.Place.Place> specification, CancellationToken token)
    {
        return await SpecificationEvaluator<VenueHosting.Domain.Place.Place>.GetQuery(_dbContext.Places, specification).ToListAsync(token);
    }
}