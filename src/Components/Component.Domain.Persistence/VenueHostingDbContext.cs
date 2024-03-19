using Component.Domain.Persistence.Conventions;
using Microsoft.EntityFrameworkCore;

namespace Component.Domain.Persistence;

public abstract class VenueHostingDbContext : DbContext
{
    public VenueHostingDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new EnumConvention());
        base.ConfigureConventions(configurationBuilder);
    }
}