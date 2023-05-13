using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Module.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<LoginQuery>();

            cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);

            cfg.Lifetime = ServiceLifetime.Transient;
        });

        serviceCollection
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationResult>();


        return serviceCollection;
    }
}