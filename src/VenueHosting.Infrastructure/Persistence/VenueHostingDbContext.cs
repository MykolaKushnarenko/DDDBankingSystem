using Microsoft.EntityFrameworkCore;
using VenueHosting.Domain.VenueDomain.Venue;

namespace VenueHosting.Infrastructure.Persistence;

public class VenueHostingDbContext : DbContext
{
    public VenueHostingDbContext(DbContextOptions<VenueHostingDbContext> options) : base(options)
    {
    }

    public DbSet<Venue> Venues { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueHostingDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}