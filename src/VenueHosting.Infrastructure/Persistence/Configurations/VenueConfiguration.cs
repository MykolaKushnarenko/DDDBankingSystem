using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

internal sealed class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        ConfigureVenueTable(builder);
        ConfigureVenueActivityTable(builder);
        ConfigureReservationIdsTable(builder);
        ConfigureVenueReviewIdsTable(builder);
    }

    private void ConfigureVenueReviewIdsTable(EntityTypeBuilder<Venue> builder)
    {
        builder.OwnsMany(x => x.VenueReviewIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("VenueId");

            navigationBuilder.ToTable("VenueReviewIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder.Property(d => d.Value)
                .HasColumnName("VenueReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Venue.VenueReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureReservationIdsTable(EntityTypeBuilder<Venue> builder)
    {
        builder.OwnsMany(x => x.ReservationIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("VenueId");

            navigationBuilder.ToTable("ReservationIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder.Property(d => d.Value)
                .HasColumnName("ReservationId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Venue.ReservationIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureVenueActivityTable(EntityTypeBuilder<Venue> builder)
    {
        builder.OwnsMany(x => x.Activities, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.WithOwner().HasForeignKey("VenueId");

            ownedNavigationBuilder.ToTable("Activities");

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
            .FindNavigation(nameof(Venue.Activities))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureVenueTable(EntityTypeBuilder<Venue> builder)
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

        builder
            .Property(x => x.EventName)
            .HasMaxLength(100);

        builder
            .Property(x => x.Description)
            .HasMaxLength(100);

        builder.Property(x => x.IsPublic)
            .HasDefaultValue(true);
    }
}