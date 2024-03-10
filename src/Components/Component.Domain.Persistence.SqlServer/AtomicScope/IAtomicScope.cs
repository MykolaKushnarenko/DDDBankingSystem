namespace Component.Persistence.SqlServer.AtomicScope;

public interface IAtomicScope : IDisposable, IAsyncDisposable
{
    Task CommitAsync(CancellationToken token);
}