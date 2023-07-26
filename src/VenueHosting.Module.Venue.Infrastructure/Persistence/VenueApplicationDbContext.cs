using Microsoft.EntityFrameworkCore;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence;

internal sealed class VenueApplicationDbContext : DbContext
{
    public VenueApplicationDbContext(DbContextOptions<VenueApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Venue.Venue> Venues { get; set; }

    public DbSet<Domain.Place.Place> Places { get; set; }

    public DbSet<Outbox.OutboxIntegrationEvent> OutboxIntegrationEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Venue");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}