
namespace VenueHosting.Module.User.Application;

public interface IAtomicScope
{
    Task CommitAsync(CancellationToken token);
}