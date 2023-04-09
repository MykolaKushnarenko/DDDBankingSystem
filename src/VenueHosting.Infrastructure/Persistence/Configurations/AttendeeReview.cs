using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.AttendeeReview;
using VenueHosting.Domain.AttendeeReview.ValueObjects;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Infrastructure.Persistence.Configurations;

internal sealed class AttendeeReviewConfiguration : IEntityTypeConfiguration<AttendeeReview>
{
    public void Configure(EntityTypeBuilder<AttendeeReview> builder)
    {
        builder.ToTable("AttendeeReviews");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AttendeeReviewId.Create(value));

        builder
            .Property(x => x.AttendeeId)
            .HasConversion(
                id => id.Value,

                value => AttendeeId.Create(value));

        builder
            .Property(x => x.VenueId)
            .HasConversion(
                id => id.Value,
                value => VenueId.Create(value));

        builder
            .Property(x => x.AuthorId)
            .HasConversion(
                id => id.Value,
                value => LesseeId.Create(value));

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