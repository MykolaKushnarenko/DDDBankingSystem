using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Outbox;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

internal interface IOutboxMessageStore
{
    Task Add(OutboxIntegrationEvent @event);

    Task<IReadOnlyList<OutboxIntegrationEvent>> FetchBatchAsync(int count = 100);
}

internal sealed class OutboxMessageStore : IOutboxMessageStore
{
    private readonly VenueApplicationDbContext _dbContext;

    public OutboxMessageStore(VenueApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(OutboxIntegrationEvent @event)
    {
        await _dbContext.OutboxIntegrationEvents.AddAsync(@event);
    }

    public async Task<IReadOnlyList<OutboxIntegrationEvent>> FetchBatchAsync(int count = 100)
    {
        return await _dbContext.OutboxIntegrationEvents
            .OrderBy(x => x.OccuredAt)
            .Take(count)
            .ToListAsync();
    }
}