using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Place.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}