using System.Transactions;
using Microsoft.EntityFrameworkCore;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace Component.Persistence.SqlServer.AtomicScope;

internal sealed class AtomicScope<TDbContext> : IAtomicScope where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DomainEventCollector _domainEventCollector;
    private readonly TransactionScope? _transactionScope;

    private bool _isCommitted;

    public AtomicScope(TDbContext dbContext,
        DomainEventCollector domainEventCollector,
        TransactionScope? transactionScope)
    {
        _dbContext = dbContext;
        _domainEventCollector = domainEventCollector;
        _transactionScope = transactionScope;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.Database
            .CreateExecutionStrategy()
            .ExecuteAsync(0,
                async (_, token) => { await _dbContext.SaveChangesAsync(token); }, cancellationToken);

        _isCommitted = true;
    }

    public void Dispose()
    {
        if (!_isCommitted)
        {
            _dbContext.Database.RollbackTransaction();
            _transactionScope?.Dispose();
        }

        _transactionScope?.Complete();
    }

    public async ValueTask DisposeAsync()
    {
        if (!_isCommitted)
        {
            await _dbContext.Database.RollbackTransactionAsync();
            _transactionScope?.Dispose();
        }

        _transactionScope?.Complete();
    }
}