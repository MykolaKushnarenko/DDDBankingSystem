namespace VenueHosting.Module.Venue.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}