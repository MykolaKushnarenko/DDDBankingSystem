using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Module.Place.Application;
using VenueHosting.Module.Place.Application.Common.Persistence;
using VenueHosting.Module.Place.Infrastructure.Persistence;
using VenueHosting.Module.Place.Infrastructure.Persistence.AtomicScope;
using VenueHosting.Module.Place.Infrastructure.Persistence.Stores;
using VenueHosting.Module.Place.Infrastructure.Services;

namespace VenueHosting.Module.Place.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPlaceInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        serviceCollection.AddScoped<IPlaceStore, PlaceStore>();

        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<PlaceApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Place")));

        return serviceCollection;
    }
}