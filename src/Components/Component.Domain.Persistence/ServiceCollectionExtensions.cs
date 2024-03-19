using Component.Domain.Persistence.AtomicScope;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace Component.Domain.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainDbContext<TDbContext>(this IServiceCollection serviceCollection,
        IConfiguration configuration) where TDbContext : DbContext
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnectionString");

        serviceCollection.TryAddScoped<DomainEventCollector>();
        serviceCollection.TryAddScoped<IAtomicScope, AtomicScope<TDbContext>>();

        serviceCollection.AddDbContext<TDbContext>(x => x.UseSqlServer(connectionString,
            builder => builder
                .MigrationsHistoryTable(HistoryRepository.DefaultTableName)
                .EnableRetryOnFailure()));
        
        //TODO: Add interceptors for auditing.
        //TODO: Add extend DBContextOptions.

        return serviceCollection;
    }
}