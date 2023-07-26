using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VenueHosting.Module.Venue.Infrastructure.Persistence.Configurations;

public class OutboxIntegrationEventConfiguration : IEntityTypeConfiguration<Outbox.OutboxIntegrationEvent>
{
    public void Configure(EntityTypeBuilder<Outbox.OutboxIntegrationEvent> builder)
    {
        builder.ToTable("OutboxIntegrationEvent");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data)
            .HasColumnName("Date");

        builder.Property(x => x.Type)
            .HasColumnName("Type");
    }
}