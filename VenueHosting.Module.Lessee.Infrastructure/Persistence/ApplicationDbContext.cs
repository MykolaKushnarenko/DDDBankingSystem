using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Lessee.Domain.LesseeReview;

namespace VenueHosting.Module.Lessee.Infrastructure.Persistence;

internal sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Lessee.Lessee> Lessees { get; set; }

    public DbSet<LesseeReview> LesseeReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Lessee");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}