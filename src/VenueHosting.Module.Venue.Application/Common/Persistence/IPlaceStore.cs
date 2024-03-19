using Component.Persistence.SqlServer.Storages;
using VenueHosting.Module.Venue.Application.Common.Specifications;

namespace VenueHosting.Module.Venue.Application.Common.Persistence;

public interface IPlaceStore : IStorageSpecification<Domain.Replicas.PlaceAggregate.Place>
{
    Task<bool> CheckIfPlaceExistAsync(FindPlaceByPlaceIdSpecification specification, CancellationToken token);

    Task<IReadOnlyList<Domain.Replicas.PlaceAggregate.Place>> FetchAllAsync(CancellationToken token);

    Task AddAsync(Domain.Replicas.PlaceAggregate.Place place, CancellationToken token);

    Task UpdateAsync(Domain.Replicas.PlaceAggregate.Place place);
}