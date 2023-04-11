using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Owner;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

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