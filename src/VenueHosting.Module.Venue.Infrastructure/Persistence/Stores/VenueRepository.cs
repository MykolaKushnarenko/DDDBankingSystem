using Component.Domain.Persistence;
using VenueHosting.Module.Venue.Domain.Repositories;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

internal sealed class VenueRepository : Repository<Domain.Aggregates.VenueAggregate.Venue>, IVenueRepository
{
    private readonly VenueApplicationDbContext _dbContext;

    public VenueRepository(VenueApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}