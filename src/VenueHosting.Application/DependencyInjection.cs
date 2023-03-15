using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Commands.Login;

namespace VenueHosting.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginCommand>());

        return serviceCollection;
    }
}