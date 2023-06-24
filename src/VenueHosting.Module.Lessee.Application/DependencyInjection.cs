using System.Reflection;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Module.Lessee.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {

        //serviceCollection.AddValidatorsFromAssemblyContaining<RegistrationResult>();

        return serviceCollection;
    }
}