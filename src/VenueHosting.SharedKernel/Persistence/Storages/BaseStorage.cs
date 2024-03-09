using VenueHosting.SharedKernel.Common.Models;
using VenueHosting.SharedKernel.Persistence.Specifications;
using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.SharedKernel.Persistence.Storages;

public interface IStorageSpecification<T> where T : AggregateRote<T>
{
    Task<T?> FetchBySpecification(ISpecification<T> specification, CancellationToken token);

    Task<IReadOnlyList<T>> FetchAllBySpecificationAsync(ISpecification<T> specification, CancellationToken token);
}