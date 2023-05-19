using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Api.Controllers;

namespace VenueHosting.Module.Venue.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddVenueControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<ControllerBase, VenuesController>();

        return serviceCollection;
    }
}