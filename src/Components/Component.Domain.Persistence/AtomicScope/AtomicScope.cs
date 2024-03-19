using System.Transactions;
using Microsoft.EntityFrameworkCore;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace Component.Domain.Persistence.AtomicScope;

internal sealed class AtomicScope<TDbContext> : IAtomicScope where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DomainEventCollector _domainEventCollector;
    
    public AtomicScope(TDbContext dbContext,
        DomainEventCollector domainEventCollector)
    {
        _dbContext = dbContext;
        _domainEventCollector = domainEventCollector;
    }

    public Task CommitAsync(Func<CancellationToken, Task> action,
        CancellationToken cancellationToken) => InternalCommitAsync(action, cancellationToken);

    public Task CommitAsync(CancellationToken cancellationToken) => InternalCommitAsync(
        delegate { return Task.CompletedTask; }, cancellationToken);
    
    private async Task InternalCommitAsync(Func<CancellationToken, Task> action,
        CancellationToken cancellationToken)
    {
        var strategy = _dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(0,
            async (state, token) =>
            {
                if (Transaction.Current is not null)
                {
                    await action(token);
                }

                await _dbContext.Database.BeginTransactionAsync(token);

                await action(token);
                
                await _dbContext.SaveChangesAsync(token);
                
                //store domain events;
                
                await _dbContext.Database.CommitTransactionAsync(token);
            }, cancellationToken);
    }
}