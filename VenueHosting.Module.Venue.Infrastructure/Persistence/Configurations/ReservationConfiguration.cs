using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Reservation;
using VenueHosting.Module.Venue.Domain.Reservation.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using ReservationId = VenueHosting.Module.Venue.Domain.Reservation.ValueObjects.ReservationId;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");

        builder.HasKey(x=> x.Id);

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => ReservationId.Create(value));

        builder
            .Property(x => x.AttendeeId)
            .HasColumnName("AttendeeId")
            .HasConversion(
                id => id.Value,
                value => AttendeeId.Create(value));

        builder
            .Property(x => x.BillId)
            .HasColumnName("BillId")
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder
            .Property(x => x.VenueId)
            .HasColumnName("VenueId")
            .HasConversion(
                id => id.Value,
                value => VenueId.Create(value));

        builder
            .Property(x => x.Amount)
            .HasColumnName("Amount");

        builder
            .Property(x => x.ReservationDateTime)
            .HasColumnName("ReservationDateTime");
    }
}