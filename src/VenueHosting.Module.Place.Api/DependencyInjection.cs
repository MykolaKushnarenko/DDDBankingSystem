using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Place.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPlaceControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHub();
        serviceCollection.AddTransient<ControllerBase, PlacesController>();

        return serviceCollection;
    }

    public static void AddHub(this IServiceCollection serviceCollection){
        serviceCollection.AddSignalR(x =>
        {
            x.EnableDetailedErrors = true;
        });
        serviceCollection.AddScoped<ViewHub>();
    }

    public static IEndpointRouteBuilder UseVenuePlaceSignalR(this IEndpointRouteBuilder builder)
    {

        builder.MapHub<ViewHub>("/hubs/view");
        builder.MapHub<CategoryHub>("/hubs/groups");

        return builder;
    }
}