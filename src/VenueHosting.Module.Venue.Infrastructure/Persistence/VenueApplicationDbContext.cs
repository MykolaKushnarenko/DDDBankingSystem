using Component.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence;

internal sealed class VenueApplicationDbContext : VenueHostingDbContext
{
    public VenueApplicationDbContext(DbContextOptions<VenueApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Aggregates.VenueAggregate.Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //TODO: Move it to the 'VenueHostingDbContext' 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueApplicationDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}