using System.Globalization;
using Component.Domain.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Aggregates.PartnerAggregate;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

public class PartnerEntityTypeConfiguration : IEntityTypeConfiguration<Partner>
{    
    private const string Scheme = nameof(Venue);
    private static readonly Inflector.Inflector Inflector = new(new CultureInfo("en-US"));
    
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.ToTable(Inflector.Pluralize(nameof(Partner)), Scheme);

        builder.HasKey(x => x.Id);
        builder.HasId(x => x.Id).HasColumnName("Id");

        builder.HasId(x => x.RepresentativeId).HasColumnName("RepresentativeId");
        builder.Property(x => x.CompanyName).HasColumnName("CompanyName").HasMaxLength(100);
    }
}