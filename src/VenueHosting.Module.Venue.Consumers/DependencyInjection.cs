using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Consumers.Consts;
using VenueHosting.Module.Venue.Consumers.OrganizeVenue;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Consumers;

public static class DependencyInjection
{
    public static IServiceCollection AddMassTransitGlobal(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransit(x =>
        {
            //x.AddSagaStateMachine<OrganizeVenueSaga, VenueState>().InMemoryRepository();

            x.AddConsumer<BookVenueConsumer>();
            x.AddConsumer<VenueCreatedIntegrationEventConsumer>();

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                configurator.Publish<IIntegrationEvent>(p => p.Exclude = true);

                configurator.ConfigureEndpoints(context);
            });

        });

        return serviceCollection;
    }
}