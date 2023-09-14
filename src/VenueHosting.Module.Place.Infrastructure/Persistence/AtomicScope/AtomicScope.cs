using System.Data.Common;
using VenueHosting.Module.Place.Application;
using IsolationLevel = System.Data.IsolationLevel;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;

internal sealed class AtomicScope : ISqlServerAtomicScope, IAtomicScope
{
    private bool _processed;

    public DbConnection Connection { get; }

    public DbTransaction Transaction { get; }

    public AtomicScope(DbConnection connection)
    {
        Connection = connection;
        Connection.Open();

        Transaction = Connection.BeginTransaction(IsolationLevel.RepeatableRead);
    }

    public async ValueTask CommitAsync(CancellationToken token)
    {
        if (_processed)
        {
            return;
        }

        await Transaction.CommitAsync(token);

        _processed = true;
    }

    public void Dispose()
    {
        if (!_processed)
        {
            Transaction.Rollback();
        }

        Connection.Dispose();
        Transaction.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (!_processed)
        {
            await Transaction.RollbackAsync();
        }

        await Connection.DisposeAsync();
        await Transaction.DisposeAsync();
    }
}