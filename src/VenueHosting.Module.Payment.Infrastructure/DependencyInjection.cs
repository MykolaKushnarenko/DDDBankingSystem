using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Module.Payment.Infrastructure.Persistence;

namespace VenueHosting.Module.Payment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPaymentInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration builderConfiguration)
    {

        serviceCollection.AddPersistence();

        return serviceCollection;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<PaymentApplicationDbContext>(options =>
            options.UseSqlServer(
                "Data Source=(local);Initial Catalog=Local-Account-Main;User Id=SA;Password=Qwerty123$%;TrustServerCertificate=true;",
                builder => builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Payment")));

        return serviceCollection;
    }
}