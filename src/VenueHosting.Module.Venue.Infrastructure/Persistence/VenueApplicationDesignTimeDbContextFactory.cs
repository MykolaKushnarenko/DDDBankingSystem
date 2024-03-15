using Component.Persistence.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence;

internal class VenueApplicationDesignTimeDbContextFactory : IDesignTimeDbContextFactory<VenueApplicationDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    public VenueApplicationDesignTimeDbContextFactory()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.local.json", true)
            .AddEnvironmentVariables()
            .Build();

        _serviceProvider = new ServiceCollection()
            .AddDomainDbContext<VenueApplicationDbContext>(configuration)
            .BuildServiceProvider();
    }

    public VenueApplicationDbContext CreateDbContext(string[] args)
    {
        var context = _serviceProvider.GetRequiredService<VenueApplicationDbContext>();
        return context;
    }
}