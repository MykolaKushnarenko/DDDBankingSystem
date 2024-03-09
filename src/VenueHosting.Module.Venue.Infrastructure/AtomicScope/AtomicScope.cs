using MassTransit;
using Newtonsoft.Json;
using VenueHosting.Module.Venue.Application;
using VenueHosting.Module.Venue.Infrastructure.Persistence;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Outbox;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Infrastructure.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly VenueApplicationDbContext _dbContext;

    public AtomicScope(VenueApplicationDbContext dbContext, IBus bus)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        //Dispatch all domain events before commiting a transaction.
        await _dbContext.DispatchEventsAsync();

        await _dbContext.SaveChangesAsync(token);
    }
}

internal static class DbExtensions
{
    public static async Task DispatchEventsAsync(this VenueApplicationDbContext context)
    {
        List<IHasDomainEvents> aggregateRoots = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        List<IDomainEvent> domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        OutboxIntegrationEvent[] outboxIntegrationEvents = domainEvents
            .Select(x => new OutboxIntegrationEvent
            {
                Type = x.GetType().FullName!,
                Data = JsonConvert.SerializeObject(x)
            })
            .ToArray();

        await context.OutboxIntegrationEvents.AddRangeAsync(outboxIntegrationEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IBus bus, List<IDomainEvent> domainEvents)
    {
        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await bus.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<IHasDomainEvents> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}