using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Component.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Component.Domain.Persistence;

public abstract class Repository<TAggregate>
    where TAggregate : class, IAggregateRote
{
    private readonly DbSet<TAggregate> _aggregateDbSet;

    protected Repository(VenueHostingDbContext dbContext)
    {
        _aggregateDbSet = dbContext.Set<TAggregate>();
    }

    public async Task<TAggregate[]> FindManyAsync(ISpecification<TAggregate> specification,
        CancellationToken cancellationToken) =>
        await _aggregateDbSet.WithSpecification(specification)
            .ToArrayAsync(cancellationToken);

    public async Task<TAggregate?> FindOneAsync(ISpecification<TAggregate> specification,
        CancellationToken cancellationToken) =>
        await _aggregateDbSet.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken);

    public void Update(TAggregate aggregate) => _aggregateDbSet.Update(aggregate);

    public void Delete(TAggregate aggregate) => _aggregateDbSet.Remove(aggregate);

    public void Add(TAggregate aggregate) => _aggregateDbSet.Add(aggregate);
}