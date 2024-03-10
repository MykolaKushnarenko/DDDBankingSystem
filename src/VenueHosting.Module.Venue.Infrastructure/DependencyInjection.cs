using Component.Persistence.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Infrastructure.Jobs;
using VenueHosting.Module.Venue.Infrastructure.Persistence;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

namespace VenueHosting.Module.Venue.Infrastructure;

public static class DependencyInjection
{
    private const string Scheme = "Venue";

    public static IServiceCollection AddVenueInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddScoped<IPlaceStore, PlaceStore>();
        serviceCollection.AddScoped<IVenueStore, VenueStore>();
        serviceCollection.AddScoped<IOutboxMessageStore, OutboxMessageStore>();

        serviceCollection.AddDbContext<VenueApplicationDbContext>(configuration, Scheme);

        serviceCollection.AddHostedService<OutboxMessageBackgroundJob>();

        return serviceCollection;
    }
}