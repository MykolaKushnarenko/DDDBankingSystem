namespace VenueHosting.Module.Place.Application;

public interface IAtomicScope : IAsyncDisposable, IDisposable
{
    ValueTask CommitAsync(CancellationToken token);
}