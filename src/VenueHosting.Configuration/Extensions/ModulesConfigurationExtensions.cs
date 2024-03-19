using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Payment.Infrastructure;
using VenueHosting.Module.Place.Api;
using VenueHosting.Module.Place.Infrastructure;
using VenueHosting.Module.User.Infrastructure;
using VenueHosting.Module.Venue.Infrastructure;
using VenueHosting.Module.Venue.Api;
using VenueHosting.Module.Venue.Application;
using VenueHosting.Module.Venue.Domain;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Configuration.Extensions
{
    public static class ModulesConfigurationExtensions
    {
        public static IServiceCollection AddVenueModule
        (
            this IServiceCollection services,
            IConfiguration builderConfiguration
            // ConfigurationSettings settings,
            // Action<PricingEngineBuilder>? setupAction = null
        )
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(IAssemblyMarker).Assembly);

                cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);

                cfg.Lifetime = ServiceLifetime.Transient;
            });

            services
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddVenueInfrastructure(builderConfiguration)
                .AddDomainServices()
                .AddApplication()
                .AddVenueControllers();

            return services;

        }

        public static IEndpointRouteBuilder UseVenueModule(this IEndpointRouteBuilder builderConfiguration)
        {
            builderConfiguration.UseVenuePlaceSignalR();

            return builderConfiguration;
        }
    }
}