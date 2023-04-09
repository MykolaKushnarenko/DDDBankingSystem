// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using VenueHosting.Domain.Attendee.ValueObjects;
// using VenueHosting.Domain.LesseeReview;
// using VenueHosting.Domain.LesseeReview.ValueObjects;
// using VenueHosting.Domain.Venue.ValueObjects;
//
// namespace VenueHosting.Infrastructure.Persistence.Configurations;
//
// internal sealed class LesseeReviewConfiguration : IEntityTypeConfiguration<LesseeReview>
// {
//     public void Configure(EntityTypeBuilder<LesseeReview> builder)
//     {
//         builder.ToTable("LesseeReviews");
//
//         builder.HasKey("Id");
//
//         builder
//             .Property(x => x.Id)
//             .ValueGeneratedNever()
//             .HasConversion(
//                 id => id.Value,
//                 value => LesseeReviewId.Create(value));
//
//         builder
//             .Property(x => x.VenueId)
//             .HasConversion(
//                 id => id.Value,
//                 value => VenueId.Create(value));
//
//         builder
//             .Property(x => x.AuthorId)
//             .HasConversion(
//                 id => id.Value,
//                 value => AttendeeId.Create(value));
//
//         builder
//             .Property(x => x.Comment)
//             .HasColumnName("Comment")
//             .HasMaxLength(1000);
//
//         builder
//             .Property(x => x.RatingGiven)
//             .HasColumnName("RatingGiven");
//
//         builder
//             .Property(x => x.CreatedDateTime)
//             .HasColumnName("CreatedDateTime");
//     }
// }