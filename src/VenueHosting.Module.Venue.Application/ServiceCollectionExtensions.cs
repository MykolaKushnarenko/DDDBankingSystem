using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Consumers;

namespace VenueHosting.Module.Venue.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransitGlobal();
        return serviceCollection;
    }
}