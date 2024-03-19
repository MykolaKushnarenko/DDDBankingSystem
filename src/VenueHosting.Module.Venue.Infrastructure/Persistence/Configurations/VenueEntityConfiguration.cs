using Component.Domain.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

public class VenueEntityConfiguration : IEntityTypeConfiguration<Domain.Aggregates.VenueAggregate.Venue>
{
    private const string Scheme = nameof(Venue);

    public void Configure(EntityTypeBuilder<Domain.Aggregates.VenueAggregate.Venue> builder)
    {
        builder.ToTable("Venues", Scheme);

        builder.HasKey(x => x.Id);

        builder
            .HasId(x => x.Id);

        builder
            .HasId(x => x.HostId)
            .HasColumnName("HostId");

        builder
            .HasId(x => x.PlaceId)
            .HasColumnName("PlaceId");

        builder
            .Property(x => x.EventName)
            .HasColumnName("EventName")
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(200);

        builder
            .Property(x => x.Visibility)
            .HasColumnName("Visibility");

        builder
            .Property(x => x.VenueStatus)
            .HasColumnName("VenueStatus");

        builder
            .Property(x => x.Capacity)
            .HasColumnName("Capacity");

        builder
            .Property(x => x.StartAtDateTime)
            .HasColumnName("StartAtDateTime");

        builder
            .Property(x => x.EndAtDateTime)
            .HasColumnName("EndAtDateTime");

        builder.OwnsOne(x => x.Schedule, BuildSchedule);

        builder.OwnsMany(x => x.Activities, BuildActivity);
        builder.OwnsMany(x => x.Partners, BuildPartner);
        builder.OwnsMany(x => x.Amenities, BuildAmenity);
    }

    private void BuildAmenity(OwnedNavigationBuilder<Domain.Aggregates.VenueAggregate.Venue, Amenity> builder)
    {
        builder.ToTable("Amenities", Scheme);

        builder.HasForeignKey();

        builder
            .HasId(x => x.Id);

        builder
            .Property(x => x.Title)
            .HasColumnName("Title")
            .HasMaxLength(50);

        builder
            .Property(x => x.Quantity)
            .HasColumnName("Quantity");

        builder
            .Property(x => x.IsAvailable)
            .HasColumnName("IsAvailable");
    }

    private void BuildPartner(OwnedNavigationBuilder<Domain.Aggregates.VenueAggregate.Venue, PartnerReference> builder)
    {
        builder.ToTable("Partners", Scheme);

        builder.HasForeignKey();

        builder.HasKey(x => x.Id);

        builder.HasId(x => x.Id);

        builder.HasId(x => x.PartnerId)
            .HasColumnName("PartnerId");
    }

    private void BuildActivity(OwnedNavigationBuilder<Domain.Aggregates.VenueAggregate.Venue, Activity> builder)
    {
        builder.ToTable("Activities", Scheme);

        builder.HasForeignKey();

        builder.HasKey(x => x.Id);

        builder.HasId(x => x.Id);

        builder
            .Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(150);
    }

    private void BuildSchedule(OwnedNavigationBuilder<Domain.Aggregates.VenueAggregate.Venue, Schedule> builder)
    {
        builder
            .Property(x => x.EndTime)
            .HasColumnName("EndTime");

        builder
            .Property(x => x.StartTime)
            .HasColumnName("StartTime");

        builder
            .Property(x => x.IsBooked)
            .HasColumnName("IsBooked");
    }
}