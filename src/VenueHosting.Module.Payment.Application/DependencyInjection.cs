using System.Reflection;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Module.Payment.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        //serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationResult>();


        return serviceCollection;
    }
}