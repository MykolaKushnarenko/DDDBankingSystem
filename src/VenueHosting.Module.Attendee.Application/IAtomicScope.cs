namespace VenueHosting.Module.Attendee.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}