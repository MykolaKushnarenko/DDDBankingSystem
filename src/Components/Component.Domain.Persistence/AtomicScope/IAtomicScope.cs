namespace Component.Domain.Persistence.AtomicScope;

public interface IAtomicScope
{
    Task CommitAsync(Func<CancellationToken, Task> action, CancellationToken token);

    Task CommitAsync(CancellationToken cancellationToken);
}