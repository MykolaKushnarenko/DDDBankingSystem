using System.Transactions;
using Microsoft.EntityFrameworkCore;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace Component.Persistence.SqlServer.AtomicScope;

internal class AtomicScopeFactory<TDbContext> : IAtomicScopeFactory where  TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DomainEventCollector _domainEventCollector;

    public AtomicScopeFactory(
        TDbContext dbContext,
        DomainEventCollector domainEventCollector)
    {
        _dbContext = dbContext;
        _domainEventCollector = domainEventCollector;
    }

    public IAtomicScope CreateAtomicScope()
    {
        if (Transaction.Current is not null)
        {
            return new AtomicScope<TDbContext>(_dbContext, _domainEventCollector, transactionScope: null);
        }

        var transactionScope = new TransactionScope();
        return new AtomicScope<TDbContext>(_dbContext, _domainEventCollector, transactionScope);
    }
}