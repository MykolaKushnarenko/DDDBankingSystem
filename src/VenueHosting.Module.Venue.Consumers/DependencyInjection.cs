
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Consumers.Consts;
using VenueHosting.Module.Venue.Consumers.OrganizeVenue;

namespace VenueHosting.Module.Venue.Consumers;

public static class DependencyInjection
{
    public static IServiceCollection AddMassTransitGlobal(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransit(x =>
        {
            x.AddSagaStateMachine<OrganizeVenueSaga, VenueState>().InMemoryRepository();

            x.AddConsumer<BookVenueConsumer>();

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                configurator.ReceiveEndpoint(EventBusConstants.BookVenueQueue, e =>
                {
                    e.ConfigureConsumer<BookVenueConsumer>(context);
                });

                configurator.ConfigureEndpoints(context);
            });

        });

        return serviceCollection;
    }
}