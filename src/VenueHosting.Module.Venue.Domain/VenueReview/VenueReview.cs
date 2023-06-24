using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.VenueReview;

public sealed class VenueReview : Entity<VenueReviewId>
{
    private VenueReview()
    {
    }

    private VenueReview(VenueReviewId id, AttendeeId authorId, string comment, float ratingGiven,
        DateTime createdDateTime) : base(id)
    {
        AuthorId = authorId;
        Comment = comment;
        RatingGiven = ratingGiven;
        CreatedDateTime = createdDateTime;
    }

    public AttendeeId AuthorId { get; private set; }

    public string Comment { get; private set; }

    public float RatingGiven { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public static VenueReview Create(AttendeeId authorId, string comment, float ratingGiven)
    {
        return new VenueReview(VenueReviewId.CreateUnique(), authorId, comment, ratingGiven,
            DateTime.UtcNow);
    }
}