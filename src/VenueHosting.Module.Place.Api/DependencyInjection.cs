using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Place.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPlaceControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ControllerBase, PlacesController>();

        return serviceCollection;
    }
}