using VenueHosting.SharedKernel.Specifications;

namespace VenueHosting.SharedKernel.Persistence;

public interface IStorageSpecification<T> where T : ISupportSpecification
{
    Task<T?> FetchBySpecification(ISpecification<T> specification, CancellationToken token);

    Task<IReadOnlyList<T>> FetchAllBySpecificationAsync(ISpecification<T> specification, CancellationToken token);
}