using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Features.Authentication.Login;

namespace VenueHosting.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginQuery>());

        return serviceCollection;
    }
}