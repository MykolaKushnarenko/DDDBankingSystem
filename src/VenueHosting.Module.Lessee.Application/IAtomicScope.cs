namespace VenueHosting.Module.Lessee.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}