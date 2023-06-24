using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Venue.Application;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Infrastructure.AtomicScope;
using VenueHosting.Module.Venue.Infrastructure.Persistence;
using VenueHosting.Module.Venue.Infrastructure.Persistence.Stores;

namespace VenueHosting.Module.Venue.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddVenueInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {

        serviceCollection.AddScoped<IPlaceStore, PlaceStore>();
        serviceCollection.AddScoped<IVenueStore, VenueStore>();

        //serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope.AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<VenueApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Venue")));

        return serviceCollection;
    }
}