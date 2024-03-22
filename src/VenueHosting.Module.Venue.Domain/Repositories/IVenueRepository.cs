using Ardalis.Specification;

namespace VenueHosting.Module.Venue.Domain.Repositories;

public interface IVenueRepository
{
    public Task<Domain.Aggregates.VenueAggregate.Venue[]> FindManyAsync(
        ISpecification<Domain.Aggregates.VenueAggregate.Venue> specification,
        CancellationToken cancellationToken);

    public Task<Domain.Aggregates.VenueAggregate.Venue?> FindOneAsync(
        ISpecification<Domain.Aggregates.VenueAggregate.Venue> specification,
        CancellationToken cancellationToken);

    public void Update(Domain.Aggregates.VenueAggregate.Venue aggregate);
    
    public void Delete(Domain.Aggregates.VenueAggregate.Venue aggregate);

    public void Add(Domain.Aggregates.VenueAggregate.Venue aggregate);
}