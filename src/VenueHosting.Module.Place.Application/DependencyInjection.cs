using System.Reflection;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Module.Place.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(Assembly.GetExecutingAssembly().GetType());

            cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);

            cfg.Lifetime = ServiceLifetime.Transient;
        });

        serviceCollection
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        //serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationResult>();


        return serviceCollection;
    }
}