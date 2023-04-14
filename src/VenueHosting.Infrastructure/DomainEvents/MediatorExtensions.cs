using MediatR;
using VenueHosting.Domain.Common.DomainEvents;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Infrastructure.Persistence;

namespace VenueHosting.Infrastructure.DomainEvents;

internal static class MediatorExtensions
{
    public static async Task DispatchEventsAsync(this IMediator mediator, VenueHostingDbContext context)
    {
        var aggregateRoots = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity != null && x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        List<IDomainEvent> domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IMediator mediator, List<IDomainEvent> domainEvents)
    {
        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<Entity> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}