using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Behaviours;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;

namespace VenueHosting.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginQuery>());

        serviceCollection
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationResult>();
        
        
        return serviceCollection;
    }
}