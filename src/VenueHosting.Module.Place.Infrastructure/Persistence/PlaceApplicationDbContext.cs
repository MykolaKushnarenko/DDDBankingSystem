using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Place.Domain.Owner;

namespace VenueHosting.Module.Place.Infrastructure.Persistence;

internal sealed class PlaceApplicationDbContext : DbContext
{
    public PlaceApplicationDbContext(DbContextOptions<PlaceApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Owner> Owners { get; set; }

    public DbSet<Domain.Place.Place> Places { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Place");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaceApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}