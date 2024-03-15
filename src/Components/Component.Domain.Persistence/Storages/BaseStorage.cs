using Component.Domain.Models;
using Component.Persistence.SqlServer.Specifications;

namespace Component.Persistence.SqlServer.Storages;

public interface IStorageSpecification<T> where T : AggregateRote<T>
{
    Task<T?> FetchBySpecification(ISpecification<T> specification, CancellationToken token);

    Task<IReadOnlyList<T>> FetchAllBySpecificationAsync(ISpecification<T> specification, CancellationToken token);
}