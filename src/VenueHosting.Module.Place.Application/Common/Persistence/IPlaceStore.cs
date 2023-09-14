using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Application.Common.Persistence;

public interface IPlaceStore
{
    Task<bool> CheckIfPlaceExistAsync(PlaceId id, IAtomicScope atomicScope);

    Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync(IAtomicScope atomicScope);

    Task<Domain.Place.Place> FetchAsync(PlaceId placeId, IAtomicScope atomicScope);

    Task<PlaceId> AddAsync(Domain.Place.Place place, IAtomicScope atomicScope);

    Task UpdateAsync(Domain.Place.Place place, IAtomicScope atomicScope);
}