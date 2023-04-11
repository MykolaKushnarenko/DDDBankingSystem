using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Reservation;
using VenueHosting.Domain.Reservation.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

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