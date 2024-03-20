using System.Globalization;
using Component.Domain.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Venue.Domain.Aggregates.UserReplica;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    private const string Scheme = "Replica";
    private static readonly Inflector.Inflector Inflector = new(new CultureInfo("en-US"));
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Inflector.Pluralize(nameof(User)), Scheme);

        builder.HasKey(x => x.Id);
        builder.HasId(x => x.Id).HasColumnName("Id");
    }
}