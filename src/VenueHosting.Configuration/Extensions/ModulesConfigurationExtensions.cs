using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Attendee.Infrastructure;
using VenueHosting.Module.Lessee.Infrastructure;
using VenueHosting.Module.Payment.Infrastructure;
using VenueHosting.Module.Place.Api;
using VenueHosting.Module.Place.Infrastructure;
using VenueHosting.Module.User.Infrastructure;
using VenueHosting.Module.Venue.Infrastructure;
using VenueHosting.Module.Venue.Api;
using VenueHosting.Module.Venue.Application;
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
                    typeof(IAssemblyMarker).Assembly,
                    typeof(Module.Place.Application.IAssemblyMarker).Assembly,
                    typeof(Module.User.Application.IAssemblyMarker).Assembly,
                    typeof(Module.Lessee.Application.IAssemblyMarker).Assembly,
                    typeof(Module.Attendee.Application.IAssemblyMarker).Assembly,
                    typeof(Module.Payment.Application.IAssemblyMarker).Assembly);

                cfg.NotificationPublisherType = typeof(TaskWhenAllPublisher);

                cfg.Lifetime = ServiceLifetime.Transient;
            });

            services
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddVenueInfrastructure(builderConfiguration)
                .AddApplication()
                .AddVenueControllers();

            services.AddUserInfrastructure(builderConfiguration);

            services.AddPlaceInfrastructure(builderConfiguration)
                .AddPlaceControllers();

            services.AddPaymentInfrastructure(builderConfiguration);

            services.AddLesseeInfrastructure(builderConfiguration);

            services.AddAttendeeInfrastructure(builderConfiguration);

            return services;

        }

        public static IEndpointRouteBuilder UseVenueModule
        (
            this IEndpointRouteBuilder builderConfiguration
        )
        {

            builderConfiguration.UseVenuePlaceSignalR();

            return builderConfiguration;

        }
    }
}