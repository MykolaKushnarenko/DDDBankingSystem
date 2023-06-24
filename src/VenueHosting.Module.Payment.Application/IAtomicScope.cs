namespace VenueHosting.Module.Payment.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}