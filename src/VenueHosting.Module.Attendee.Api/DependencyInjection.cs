using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Attendee.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddAttendeeControllers(this IServiceCollection serviceCollection)
    {
        //serviceCollection.AddTransient<ControllerBase, VenuesController>();

        return serviceCollection;
    }
}