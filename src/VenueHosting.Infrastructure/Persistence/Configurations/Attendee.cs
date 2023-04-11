using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Attendee;
using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

internal sealed class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
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

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.VenueIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.BillIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.AttendeeReviewIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("AttendeeId");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("AttendeeReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Attendee.ReservationIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Attendee.VenueIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Attendee.BillIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Attendee.AttendeeReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}