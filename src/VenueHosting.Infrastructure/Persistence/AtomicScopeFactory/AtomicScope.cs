using VenueHosting.Application.Common.Persistence.AtomicScope;

namespace VenueHosting.Infrastructure.Persistence.AtomicScopeFactory;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly VenueHostingDbContext _dbContext;

    public AtomicScope(VenueHostingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}