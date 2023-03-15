using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Infrastructure.Authentication;
using VenueHosting.Infrastructure.Configuration;
using VenueHosting.Infrastructure.Persistence;
using VenueHosting.Infrastructure.Services;

namespace VenueHosting.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        ConfigurationManager builderConfiguration)
    {
        serviceCollection.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));

        serviceCollection.AddScoped<IUserStore, UserStore>();
        
        serviceCollection.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return serviceCollection;
    }
}