using Microsoft.AspNetCore.Hosting;
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

            services.AddVenueInfrastructure(builderConfiguration)
                .AddVenueControllers();

            services.AddUserInfrastructure(builderConfiguration);

            services.AddPlaceInfrastructure(builderConfiguration)
                .AddPlaceControllers();

            services.AddPaymentInfrastructure(builderConfiguration);

            services.AddLesseeInfrastructure(builderConfiguration);

            services.AddAttendeeInfrastructure(builderConfiguration);

            return services;

        }
    }
}