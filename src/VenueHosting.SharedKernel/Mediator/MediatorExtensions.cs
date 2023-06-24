using MediatR;
using Microsoft.EntityFrameworkCore;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.SharedKernel.Mediator;

internal static class MediatorExtensions
{
    public static async Task DispatchEventsAsync(this IPublisher mediator, DbContext context)
    {
        List<IHasDomainEvents> aggregateRoots = context.ChangeTracker
            .Entries<IHasDomainEvents>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        List<IntegrationEvent> domainEvents = aggregateRoots
            .SelectMany(x => x.DomainEvents)
            .ToList();

        await mediator.DispatchDomainEventsAsync(domainEvents);

        ClearDomainEvents(aggregateRoots);
    }

    private static async Task DispatchDomainEventsAsync(this IPublisher mediator, List<IntegrationEvent> domainEvents)
    {
        foreach (IntegrationEvent domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }

    private static void ClearDomainEvents(List<IHasDomainEvents> aggregateRoots)
    {
        aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
    }
}