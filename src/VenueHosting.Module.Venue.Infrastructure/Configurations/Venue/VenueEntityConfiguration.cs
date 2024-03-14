using Component.Domain.Models;
using Component.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Aggregates.Partner;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Infrastructure.Configurations.Venue;

public class VenueEntityConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Venue.Venue>
{
    private const string Scheme = nameof(Venue);

    public void Configure(EntityTypeBuilder<Domain.Aggregates.Venue.Venue> builder)
    {
        builder.ToTable("Venues", Scheme);

        builder.HasKey(x => x.Id);

        builder
            .HasId(x => x.Id)
            .HasColumnName("Id");

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
    }

    private void BuildPartner(OwnedNavigationBuilder<Domain.Aggregates.Venue.Venue, Id<Partner>> builder)
    {
        builder.ToTable("Partners", Scheme);

        builder.HasForeignKey();

        builder.HasId(x => x);
    }

    private void BuildActivity(OwnedNavigationBuilder<Domain.Aggregates.Venue.Venue, Activity> builder)
    {
        builder.ToTable("Activities", Scheme);

        builder.HasForeignKey();

        builder.HasKey(x => x.Id);

        builder
            .HasId(x => x.Id)
            .HasColumnName("ActivityId");

        builder
            .Property(x => x.Name)
            .HasColumnName("Name")
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .HasColumnName("Description")
            .HasMaxLength(150);
    }

    private void BuildSchedule(OwnedNavigationBuilder<Domain.Aggregates.Venue.Venue, Schedule> builder)
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