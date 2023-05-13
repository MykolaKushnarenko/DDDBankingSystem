namespace VenueHosting.SharedKernel.Persistence.AtomicScope;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}