using VenueHosting.Module.Place.Application.Common.Specifications;
using VenueHosting.SharedKernel.Persistence;

namespace VenueHosting.Module.Place.Application.Common.Persistence;

public interface IPlaceStore : IStorageSpecification<Domain.Place.Place>
{
    Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification, CancellationToken token);

    Task<IReadOnlyList<Domain.Place.Place>> FetchAllAsync(CancellationToken token);

    Task AddAsync(Domain.Place.Place place, CancellationToken token);

    Task UpdateAsync(Domain.Place.Place place);
}