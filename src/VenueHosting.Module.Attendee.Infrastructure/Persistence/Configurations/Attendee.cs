using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;

namespace VenueHosting.Module.Attendee.Infrastructure.Persistence.Configurations;

internal sealed class AttendeeConfiguration : IEntityTypeConfiguration<Domain.Attendee.Attendee>
{
    public void Configure(EntityTypeBuilder<Domain.Attendee.Attendee> builder)
    {
        builder.ToTable("Attendees");

        builder.HasKey("Id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AttendeeId.Create(value));

        builder
            .Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.OwnsMany(x => x.ReservationIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.ToTable("AttendeeReservationIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.VenueIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.ToTable("AttendeeVenueIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.BillIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.ToTable("AttendeeBillIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.AttendeeReviewIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.ToTable("AttendeeReviewIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("AttendeeReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Domain.Attendee.Attendee.ReservationIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Domain.Attendee.Attendee.VenueIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Domain.Attendee.Attendee.BillIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Domain.Attendee.Attendee.AttendeeReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}