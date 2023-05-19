using MediatR;
using VenueHosting.SharedKernel.Persistence.AtomicScope;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly PlaceApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;

    public AtomicScope(PlaceApplicationDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        //Dispatch all domain events before commiting a transaction.
        //await _publisher.DispatchEventsAsync(_dbContext);

        await _dbContext.SaveChangesAsync(token);
    }
}