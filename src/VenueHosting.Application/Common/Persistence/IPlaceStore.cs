using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Place;

namespace VenueHosting.Application.Common.Persistence;

public interface IPlaceStore : IStorageSpecification<Place>
{
    Task<IReadOnlyList<Place>> FetchAllAsync(CancellationToken token);

    Task AddAsync(Place place, CancellationToken token);
}