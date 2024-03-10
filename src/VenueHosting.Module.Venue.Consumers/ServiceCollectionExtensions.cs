using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Venue.Consumers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMassTransitGlobal(this IServiceCollection serviceCollection)
    {

        return serviceCollection;
    }
}