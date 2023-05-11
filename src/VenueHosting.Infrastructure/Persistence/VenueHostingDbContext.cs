using Microsoft.EntityFrameworkCore;
using VenueHosting.Domain.Attendee;
using VenueHosting.Domain.AttendeeReview;
using VenueHosting.Domain.Bill;
using VenueHosting.Domain.Lessee;
using VenueHosting.Domain.LesseeReview;
using VenueHosting.Domain.Owner;
using VenueHosting.Domain.Place;
using VenueHosting.Domain.Reservation;
using VenueHosting.Domain.User;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.VenueReview;

namespace VenueHosting.Infrastructure.Persistence;

internal sealed class VenueHostingDbContext : DbContext
{
    public VenueHostingDbContext(DbContextOptions<VenueHostingDbContext> options) : base(options)
    {
    }

    public DbSet<Venue> Venues { get; set; } = null!;

    public DbSet<VenueReview> VenueReview { get; set; }

    public DbSet<Attendee> Attendees { get; set; }

    public DbSet<AttendeeReview> AttendeeReviews { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<Lessee> Lessees { get; set; }

    public DbSet<LesseeReview> LesseeReviews { get; set; }

    public DbSet<Owner> Owners { get; set; }

    public DbSet<Place> Places { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Reservation> Reservations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VenueHostingDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}