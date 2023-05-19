using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Lessee.Domain.Lessee;
using VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;

namespace VenueHosting.Module.Lessee.Infrastructure.Persistence.Configurations;

internal sealed class LesseeConfiguration : IEntityTypeConfiguration<Domain.Lessee.Lessee>
{
    public void Configure(EntityTypeBuilder<Domain.Lessee.Lessee> builder)
    {
        builder.ToTable("Lessees");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => LesseeId.Create(value));

        builder
            .Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.OwnsMany(x => x.VenueIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("LesseeId");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.OwnsMany(x => x.LesseeReviewIds, navigationBuilder =>
        {
            navigationBuilder.WithOwner().HasForeignKey("LesseeId");

            navigationBuilder.ToTable("LesseeReviewIds");

            navigationBuilder.HasKey("Id");

            navigationBuilder
                .Property(x => x.Value)
                .HasColumnName("Id")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Domain.Lessee.Lessee.VenueIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata
            .FindNavigation(nameof(Domain.Lessee.Lessee.LesseeReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}