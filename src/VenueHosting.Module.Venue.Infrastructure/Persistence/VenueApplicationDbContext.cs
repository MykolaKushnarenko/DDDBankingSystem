using Microsoft.EntityFrameworkCore;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence;

internal sealed class VenueApplicationDbContext : DbContext
{
    public VenueApplicationDbContext(DbContextOptions<VenueApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Aggregates.Venue.Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}