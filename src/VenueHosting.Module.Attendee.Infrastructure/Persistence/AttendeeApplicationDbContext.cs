using Microsoft.EntityFrameworkCore;
using VenueHosting.Module.Attendee.Domain.AttendeeReview;

namespace VenueHosting.Module.Attendee.Infrastructure.Persistence;

internal sealed class AttendeeApplicationDbContext : DbContext
{
    public AttendeeApplicationDbContext(DbContextOptions<AttendeeApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Attendee.Attendee> Attendees { get; set; }

    public DbSet<AttendeeReview> AttendeeReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Attendee");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendeeApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}