using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Module.Lessee.Application.Common.Persistence;
using VenueHosting.Module.Lessee.Infrastructure.Persistence;
using VenueHosting.Module.Lessee.Infrastructure.Persistence.AtomicScope;
using VenueHosting.Module.Lessee.Infrastructure.Persistence.Stores;
using VenueHosting.Module.Lessee.Infrastructure.Services;
using VenueHosting.SharedKernel.Persistence.AtomicScope;

namespace VenueHosting.Module.Lessee.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddLesseeInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {
        serviceCollection.AddScoped<ILesseeStore, LesseeStore>();

        serviceCollection.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        serviceCollection.AddScoped<IAtomicScope, AtomicScope>();

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<LesseeApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Lessee")));

        return serviceCollection;
    }
}