using Component.Domain.Models;
using Component.Domain.Persistence.AtomicScope;

namespace VenueHosting.Module.Place.Application.Common.Persistence;

public interface IPlaceStore
{
    Task<bool> CheckIfPlaceExistAsync(Id<Domain.Place.Place> id, IAtomicScope atomicScope);

    Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync();

    Task<Domain.Place.Place> FetchAsync(Id<Domain.Place.Place> placeId);

    Task<Id<Domain.Place.Place>> AddAsync(Domain.Place.Place place);

    Task UpdateAsync(Domain.Place.Place place);
}