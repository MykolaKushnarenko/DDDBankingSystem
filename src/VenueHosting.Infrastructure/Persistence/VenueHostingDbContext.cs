using Microsoft.EntityFrameworkCore;
using VenueHosting.Domain.Attendee;
using VenueHosting.Domain.AttendeeReview;
using VenueHosting.Domain.Bill;
using VenueHosting.Domain.Reservation;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.VenueReview.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence;

public class VenueHostingDbContext : DbContext
{
    public VenueHostingDbContext(DbContextOptions<VenueHostingDbContext> options) : base(options)
    {
    }

    // public DbSet<Venue> Venues { get; set; } = null!;
    //
    // public DbSet<VenueReviewId> VenueReviewIds { get; set; }

    //public DbSet<Attendee> Attendees { get; set; }

    public DbSet<AttendeeReview> AttendeeReviews { get; set; }


    //public DbSet<Bill> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueHostingDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}