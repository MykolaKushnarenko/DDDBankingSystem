using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Place.Application.Common.Persistence;
using VenueHosting.Module.Place.Infrastructure.Persistence;
using VenueHosting.Module.Place.Infrastructure.Persistence.TypeMappers;

namespace VenueHosting.Module.Place.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlaceInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        //serviceCollection.AddScoped<IPlaceStore, PlaceStore>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<DbContextOptions>(_ => new DbContextOptions
        {
            ConnectionString =
                "Data Source=(local);Initial Catalog=VenuePlace;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;"
        });

        //serviceCollection.AddSingleton<IPlaceStore, PlaceStore>();
        serviceCollection.AddSingleton<IDbConnectionFactory, SqlServerConnectionFactory>();
        //serviceCollection.AddSingleton<IAtomicScopeFactory, AtomicFactory>();

        serviceCollection.AddSingleton<IStartupFilter, DbMigrator>();

        ConfigureDapperMapperHandlers();

        return serviceCollection;
    }

    private static void ConfigureDapperMapperHandlers()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        SqlMapper.AddTypeHandler(new SqlGuidTypeHandler());

        //Mapping for typed ids.
        SqlMapper.AddTypeHandler(new SqlOwnerIdTypeHandler());
        SqlMapper.AddTypeHandler(new SqlPlaceIdTypeHandler());

        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));
    }

}