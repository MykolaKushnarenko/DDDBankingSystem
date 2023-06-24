namespace VenueHosting.Module.Place.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}