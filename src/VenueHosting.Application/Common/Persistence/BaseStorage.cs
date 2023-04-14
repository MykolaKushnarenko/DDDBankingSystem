using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Application.Common.Persistence;

public interface IStorageSpecification<T> where T : IAggregateRote
{
    Task<IReadOnlyList<T>> FetchAllBySpecificationAsync(ISpecification<T> specification, CancellationToken token);
}