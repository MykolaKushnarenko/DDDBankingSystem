using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Reservation;
using VenueHosting.Module.Venue.Domain.Reservation.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using ReservationId = VenueHosting.Module.Venue.Domain.Reservation.ValueObjects.ReservationId;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

internal sealed class PlaceConfiguration : IEntityTypeConfiguration<Domain.Place.Place>
{
    public void Configure(EntityTypeBuilder<Domain.Place.Place> builder)
    {
        builder.ToTable("Places");

        builder.HasKey(x=> x.Id);

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => PlaceId.Create(value));

        builder
            .Property(x => x.City)
            .HasColumnName("City")
            .HasMaxLength(100);

        builder
            .Property(x => x.Street)
            .HasColumnName("Street")
            .HasMaxLength(100);

        builder
            .Property(x => x.Country)
            .HasColumnName("Country")
            .HasMaxLength(100);
    }
}