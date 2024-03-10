using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Venue.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVenueControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().AddApplicationPart(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}