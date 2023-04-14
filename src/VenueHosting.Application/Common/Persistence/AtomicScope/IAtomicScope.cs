namespace VenueHosting.Application.Common.Persistence.AtomicScope;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}