using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

internal sealed class VenueConfiguration : IEntityTypeConfiguration<Domain.Venue.Venue>
{
    public void Configure(EntityTypeBuilder<Domain.Venue.Venue> builder)
    {
        ConfigureVenueTable(builder);
        ConfigureVenueActivityTable(builder);
        ConfigureReservationsTable(builder);
        ConfigureVenueReviewsTable(builder);
    }

    private void ConfigureVenueReviewsTable(EntityTypeBuilder<Domain.Venue.Venue> builder)
    {
        builder.OwnsMany(x => x.VenueReviews, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("VenueId");

            navigationBuilder.ToTable("VenueReviews");

            navigationBuilder.HasKey("Id");

            navigationBuilder.Property(d => d.Id)
                .HasColumnName("VenueReviewId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => VenueReviewId.Create(value));

            navigationBuilder
                .Property(x => x.AuthorId)
                .HasConversion(
                    id => id.Value,
                    value => AttendeeId.Create(value));

            navigationBuilder
                .Property(x => x.Comment)
                .HasColumnName("Comment")
                .HasMaxLength(1000);

            navigationBuilder
                .Property(x => x.RatingGiven)
                .HasColumnName("RatingGiven");

            navigationBuilder
                .Property(x => x.CreatedDateTime)
                .HasColumnName("CreatedDateTime");
        });

        builder.Metadata
            .FindNavigation(nameof(Domain.Venue.Venue.VenueReviews))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureReservationsTable(EntityTypeBuilder<Domain.Venue.Venue> builder)
    {
        builder.OwnsMany(x => x.Reservations, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("VenueId");

            navigationBuilder.ToTable("VenueReservations");

            navigationBuilder.HasKey("Id");

            navigationBuilder.Property(d => d.Id)
                .HasColumnName("ReservationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value));

            navigationBuilder
                .Property(x => x.AttendeeId)
                .HasColumnName("AttendeeId")
                .HasConversion(
                    id => id.Value,
                    value => AttendeeId.Create(value));

            navigationBuilder
                .Property(x => x.BillId)
                .HasColumnName("BillId")
                .HasConversion(
                    id => id.Value,
                    value => BillId.Create(value));

            navigationBuilder
                .Property(x => x.Amount)
                .HasColumnName("Amount");

            navigationBuilder
                .Property(x => x.ReservationDateTime)
                .HasColumnName("ReservationDateTime");
        });

        builder.Metadata
            .FindNavigation(nameof(Domain.Venue.Venue.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureVenueActivityTable(EntityTypeBuilder<Domain.Venue.Venue> builder)
    {
        builder.OwnsMany(x => x.Activities, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.WithOwner().HasForeignKey("VenueId");

            ownedNavigationBuilder.ToTable("VenueActivities");

            ownedNavigationBuilder.HasKey("Id");

            ownedNavigationBuilder.Property(s => s.Id)
                .HasColumnName("ActivityId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ActivityId.Create(value));

            ownedNavigationBuilder.Property(x => x.Name)
                .HasMaxLength(100);

            ownedNavigationBuilder.Property(x => x.Description)
                .HasMaxLength(100);
        });

        builder.Metadata
            .FindNavigation(nameof(Domain.Venue.Venue.Activities))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureVenueTable(EntityTypeBuilder<Domain.Venue.Venue> builder)
    {
        builder.ToTable("Venues");
        builder.HasKey("Id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => VenueId.Create(value));

        builder
            .Property(x => x.PlaceId)
            .HasConversion(
                id => id.Value,
                value => PlaceId.Create(value));

        builder
            .Property(x => x.LesseeId)
            .HasConversion(
                id => id.Value,
                value => LesseeId.Create(value));

        builder
            .Property(x => x.OwnerId)
            .HasConversion(
                id => id.Value,
                value => OwnerId.Create(value));

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasConversion(status => status.ToString(),
                value => (VenueStatus)Enum.Parse(typeof(VenueStatus), value));

        builder
            .Property(x => x.EventName)
            .HasMaxLength(100);

        builder
            .Property(x => x.Description)
            .HasMaxLength(100);

        builder.Property(x => x.Visibility);
    }
}