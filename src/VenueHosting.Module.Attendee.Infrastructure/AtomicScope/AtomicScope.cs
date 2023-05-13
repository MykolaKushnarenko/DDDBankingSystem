using MediatR;
using VenueHosting.Module.Attendee.Infrastructure.Persistence;
using VenueHosting.SharedKernel.Persistence.AtomicScope;

namespace VenueHosting.Module.Attendee.Infrastructure.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;

    public AtomicScope(ApplicationDbContext dbContext, IPublisher publisher)
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