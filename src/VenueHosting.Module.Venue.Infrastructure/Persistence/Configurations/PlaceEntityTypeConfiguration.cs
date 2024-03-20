using System.Globalization;
using Component.Domain.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Aggregates.PlaceReplica;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

public class PlaceEntityTypeConfiguration : IEntityTypeConfiguration<Place>
{
    private const string Scheme = "Replica";
    private static readonly Inflector.Inflector Inflector = new(new CultureInfo("en-US"));

    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable(Inflector.Pluralize(nameof(Place)), Scheme);

        builder.HasKey(x => x.Id);

        builder.HasId(x => x.Id).HasColumnName("Id");
        builder.Property(x => x.City).HasColumnName("City").HasMaxLength(50);
        builder.Property(x => x.Country).HasColumnName("Country").HasMaxLength(50);
        builder.Property(x => x.Street).HasColumnName("Street").HasMaxLength(50);
    }
}