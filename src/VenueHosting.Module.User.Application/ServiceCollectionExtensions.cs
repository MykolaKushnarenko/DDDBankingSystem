using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.User.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}