using Component.Persistence.SqlServer.AtomicScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Component.Persistence.SqlServer;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext<TDbContext>(this IServiceCollection serviceCollection,
        IConfiguration configuration) where TDbContext : DbContext =>
        AddDbContext<TDbContext>(serviceCollection, configuration, "dbo");

    public static IServiceCollection AddDbContext<TDbContext>(this IServiceCollection serviceCollection,
        IConfiguration configuration, string scheme) where TDbContext : DbContext
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnectionString");

        serviceCollection.TryAddSingleton<IAtomicFactory, AtomicFactory<TDbContext>>();

        serviceCollection.AddDbContext<TDbContext>(x => x.UseSqlServer(connectionString,
            builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, scheme)));

        return serviceCollection;
    }
}