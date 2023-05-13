using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Payment.Domain.Bill;
using VenueHosting.Module.Payment.Domain.Bill.ValueObjects;

namespace VenueHosting.Module.Payment.Infrastructure.Persistence.Configurations;

internal sealed class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");
        builder.HasKey("Id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder
            .Property(x => x.AttendeeId)
            .HasConversion(
                id => id.Value,
                value => AttendeeId.Create(value));

        builder
            .Property(x => x.LesseeId)
            .HasConversion(
                id => id.Value,
                value => LesseeId.Create(value));

        builder
            .Property(x => x.VenueId)
            .HasConversion(
                id => id.Value,
                value => VenueId.Create(value));

        builder
            .Property(x => x.CreatedDateTime)
            .HasMaxLength(100);

        builder
            .Property(x => x.UpdatedDateTime)
            .HasMaxLength(100);

        builder.OwnsOne(x => x.Price);
    }
}