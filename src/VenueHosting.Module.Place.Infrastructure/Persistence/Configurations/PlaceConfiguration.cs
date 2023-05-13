using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.Configurations;

internal sealed class PlaceConfiguration : IEntityTypeConfiguration<VenueHosting.Domain.Place.Place>
{
    public void Configure(EntityTypeBuilder<VenueHosting.Domain.Place.Place> builder)
    {
        ConfigurePlaceTable(builder);
        ConfigureFacilityTable(builder);
    }

    private void ConfigureFacilityTable(EntityTypeBuilder<VenueHosting.Domain.Place.Place> builder)
    {
        builder.OwnsMany(x => x.Facilities, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("PlaceId");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => FacilityId.Create(value));

            navigationBuilder
                .Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(100);

            navigationBuilder
                .Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(50);

            navigationBuilder
                .Property(x => x.Quantity)
                .HasColumnName("Quantity");
        });

        builder.Metadata
            .FindNavigation(nameof(VenueHosting.Domain.Place.Place.Facilities))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePlaceTable(EntityTypeBuilder<VenueHosting.Domain.Place.Place> builder)
    {
        builder.ToTable("Places");

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PlaceId.Create(value));

        builder
            .Property(x => x.OwnerId)
            .HasColumnName("OwnerId")
            .HasConversion(
                id => id.Value,
                value => OwnerId.Create(value));

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasConversion(status => status.ToString(),
                value => (PlaceStatus)Enum.Parse(typeof(PlaceStatus), value));

        builder.OwnsOne(x => x.Address);
    }
}