using Component.Domain.Models;
using Component.Persistence.SqlServer.AtomicScope;

namespace VenueHosting.Module.Place.Application.Common.Persistence;

public interface IPlaceStore
{
    Task<bool> CheckIfPlaceExistAsync(Id<Domain.Place.Place> id, IAtomicScope atomicScope);

    Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync(IAtomicScope atomicScope);

    Task<Domain.Place.Place> FetchAsync(Id<Domain.Place.Place> placeId, IAtomicScope atomicScope);

    Task<Id<Domain.Place.Place>> AddAsync(Domain.Place.Place place, IAtomicScope atomicScope);

    Task UpdateAsync(Domain.Place.Place place, IAtomicScope atomicScope);
}