using System.Reflection;
using DbUp;
using DbUp.Engine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace VenueHosting.Module.Place.Infrastructure.Persistence;

internal sealed class DbMigrator : IStartupFilter
{
    private readonly DbContextOptions _contextOptions;
    private readonly ILogger<DbMigrator> _logger;

    public DbMigrator(DbContextOptions contextOptions, ILogger<DbMigrator> logger)
    {
        _contextOptions = contextOptions;
        _logger = logger;
    }

    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        EnsureDatabase.For.SqlDatabase(_contextOptions.ConnectionString);

        UpgradeEngine? upgradeEngine = DeployChanges.To
            .SqlDatabase(_contextOptions.ConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .WithTransaction()
            .LogToConsole()
            .Build();

        DatabaseUpgradeResult? result = upgradeEngine.PerformUpgrade();

        if (!result.Successful)
        {
            _logger.LogError(result.Error, "An error occurred while migrating the sql server database");
        }

        _logger.LogInformation("Successfully migrated sql server database");

        return next;
    }
}