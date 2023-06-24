using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Consumers;

namespace VenueHosting.Module.Venue.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransitGlobal();
        return serviceCollection;
    }
}