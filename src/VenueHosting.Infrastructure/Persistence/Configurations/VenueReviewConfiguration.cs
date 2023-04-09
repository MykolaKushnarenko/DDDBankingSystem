using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;
using VenueHosting.Domain.VenueReview;
using VenueHosting.Domain.VenueReview.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

internal sealed class VenueReviewConfiguration : IEntityTypeConfiguration<VenueReview>
{
    public void Configure(EntityTypeBuilder<VenueReview> builder)
    {
        builder.ToTable("VenueReviews");

        builder.HasKey("Id");

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => VenueReviewId.Create(value));

        builder
            .Property(x => x.VenueId)
            .HasConversion(
                id => id.Value,
                value => VenueId.Create(value));

        builder
            .Property(x => x.AuthorId)
            .HasConversion(
                id => id.Value,
                value => AttendeeId.Create(value));

        builder
            .Property(x => x.Comment)
            .HasColumnName("Comment")
            .HasMaxLength(1000);

        builder
            .Property(x => x.RatingGiven)
            .HasColumnName("RatingGiven");

        builder
            .Property(x => x.CreatedDateTime)
            .HasColumnName("CreatedDateTime");
    }
}