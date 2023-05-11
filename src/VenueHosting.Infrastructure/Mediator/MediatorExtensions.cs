using MediatR;
using VenueHosting.Domain.Common.DomainEvents;
using VenueHosting.Infrastructure.Persistence;

namespace VenueHosting.Infrastructure.Mediator;

internal static class MediatorExtensions
{
    public static async Task DispatchEventsAsync(this IPublisher mediator, VenueHostingDbContext context)
    {
        List<IHasDomainEvents> aggregateRoots = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        List<IDomainEvent> domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IPublisher mediator, List<IDomainEvent> domainEvents)
    {
        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<IHasDomainEvents> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}