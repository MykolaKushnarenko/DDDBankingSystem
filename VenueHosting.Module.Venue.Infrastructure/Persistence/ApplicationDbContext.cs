using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Venue.Domain.VenueReview;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence;

internal sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Venue.Venue> Venues { get; set; } = null!;

    public DbSet<VenueReview> VenueReview { get; set; }

    public DbSet<Domain.Place.Place> Places { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Venue");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}