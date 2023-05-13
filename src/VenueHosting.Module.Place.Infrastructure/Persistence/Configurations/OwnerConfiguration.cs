using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Place.Domain.Owner;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;

namespace VenueHosting.Module.Place.Infrastructure.Persistence.Configurations;

internal sealed class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners");

        builder.HasKey("Id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => OwnerId.Create(value));

        builder
            .Property(x => x.UserId)
                .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.OwnsMany(x => x.PlaceIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("OwnerId");

            navigationBuilder.ToTable("OwnerPlaceIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Owner.PlaceIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}