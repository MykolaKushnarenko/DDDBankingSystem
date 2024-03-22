using Component.Domain.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Domain.Repositories;
using VenueHosting.Module.Venue.Infrastructure.Persistence;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

namespace VenueHosting.Module.Venue.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVenueInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddScoped<IVenueRepository, VenueRepository>();

        serviceCollection.AddDomainDbContext<VenueApplicationDbContext>(configuration);

        return serviceCollection;
    }
}