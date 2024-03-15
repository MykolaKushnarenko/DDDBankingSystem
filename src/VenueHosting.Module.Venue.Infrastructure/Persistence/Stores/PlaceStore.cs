// using Component.Persistence.SqlServer.Specifications;
// using Microsoft.EntityFrameworkCore;
// using VenueHosting.Module.Venue.Application.Common.Persistence;
// using VenueHosting.Module.Venue.Application.Common.Specifications;
//
// namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;
//
// internal sealed class PlaceStore : IPlaceStore
// {
//     private readonly VenueApplicationDbContext _dbContext;
//
//     public PlaceStore(VenueApplicationDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//
//     public async Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification,
//         CancellationToken token)
//     {
//         return await SpecificationEvaluator<Domain.Replicas.Place.Place>.GetQuery(_dbContext.Places, specification).AnyAsync(token);
//     }
//
//     public async Task<IReadOnlyList<Domain.Replicas.Place.Place>> FetchAllAsync(CancellationToken token)
//     {
//         //TODO: That's critical, add with cursor paging.
//         return await _dbContext.Places.ToListAsync(token);
//     }
//
//
//     public async Task AddAsync(Domain.Replicas.Place.Place place, CancellationToken token)
//     {
//
//         await _dbContext.Places.AddAsync(place, token);
//     }
//
//     public Task UpdateAsync(Domain.Replicas.Place.Place place)
//     {
//         _dbContext.Places.Update(place);
//
//         return Task.CompletedTask;
//     }
//
//     public async Task<Domain.Replicas.Place.Place?> FetchBySpecification(ISpecification<Domain.Replicas.Place.Place> specification, CancellationToken token)
//     {
//         return await SpecificationEvaluator<Domain.Replicas.Place.Place>.GetQuery(_dbContext.Places, specification).FirstOrDefaultAsync(token);
//     }
//
//     public async Task<IReadOnlyList<Domain.Replicas.Place.Place>> FetchAllBySpecificationAsync(ISpecification<Domain.Replicas.Place.Place> specification, CancellationToken token)
//     {
//         return await SpecificationEvaluator<Domain.Replicas.Place.Place>.GetQuery(_dbContext.Places, specification).ToListAsync(token);
//     }
// }