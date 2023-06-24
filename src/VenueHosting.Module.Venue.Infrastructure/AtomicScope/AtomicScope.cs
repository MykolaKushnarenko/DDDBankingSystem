using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Application;
using VenueHosting.Module.Venue.Infrastructure.Persistence;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Infrastructure.AtomicScope;

internal sealed class AtomicScope : IAtomicScope
{
    private readonly VenueApplicationDbContext _dbContext;
    private readonly IBus _bus;

    public AtomicScope(VenueApplicationDbContext dbContext, IBus bus)
    {
        _dbContext = dbContext;
        _bus = bus;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        //Dispatch all domain events before commiting a transaction.
        await _bus.DispatchEventsAsync(_dbContext);

        await _dbContext.SaveChangesAsync(token);
    }
}

internal static class BusExtensions
{
    public static async Task DispatchEventsAsync(this IBus bus, DbContext context)
    {
        List<IHasDomainEvents> aggregateRoots = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        List<IntegrationEvent> domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        await bus.DispatchDomainEventsAsync(domainEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IBus bus, List<IntegrationEvent> domainEvents)
    {
        foreach (IntegrationEvent domainEvent in domainEvents)
        {
            await bus.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<IHasDomainEvents> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}