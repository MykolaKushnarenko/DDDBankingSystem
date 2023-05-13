using VenueHosting.Module.Place.Application.Common.Specifications;
using VenueHosting.SharedKernel.Persistence;

namespace VenueHosting.Module.Place.Application.Common.Persistence;

public interface IPlaceStore : IStorageSpecification<VenueHosting.Domain.Place.Place>
{
    Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification, CancellationToken token);

    Task<IReadOnlyList<VenueHosting.Domain.Place.Place>> FetchAllAsync(CancellationToken token);

    Task AddAsync(VenueHosting.Domain.Place.Place place, CancellationToken token);

    Task UpdateAsync(VenueHosting.Domain.Place.Place place);
}