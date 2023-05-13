using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;
using VenueHosting.Module.Attendee.Domain.AttendeeReview;
using VenueHosting.Module.Attendee.Domain.AttendeeReview.ValueObjects;

namespace VenueHosting.Module.Attendee.Infrastructure.Persistence.Configurations;

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