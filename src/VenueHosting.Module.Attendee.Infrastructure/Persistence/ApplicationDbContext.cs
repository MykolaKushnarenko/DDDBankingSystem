using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Attendee.Domain.AttendeeReview;

namespace VenueHosting.Module.Attendee.Infrastructure.Persistence;

internal sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Attendee.Attendee> Attendees { get; set; }

    public DbSet<AttendeeReview> AttendeeReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Attendee");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}