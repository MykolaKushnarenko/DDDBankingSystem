using MediatR;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Infrastructure.Mediator;

namespace VenueHosting.Infrastructure.Persistence.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly VenueHostingDbContext _dbContext;
    private readonly IPublisher _publisher;

    public AtomicScope(VenueHostingDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        //Dispatch all domain events before commiting a transaction.
        await _publisher.DispatchEventsAsync(_dbContext);

        await _dbContext.SaveChangesAsync(token);
    }
}