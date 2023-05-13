using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.VenueReview;

public sealed class VenueReview : AggregateRote<VenueReviewId, Guid>
{
    private VenueReview()
    {
    }

    private VenueReview(VenueReviewId id, AttendeeId authorId, VenueId venueId, string comment, float ratingGiven,
        DateTime createdDateTime) : base(id)
    {
        AuthorId = authorId;
        VenueId = venueId;
        Comment = comment;
        RatingGiven = ratingGiven;
        CreatedDateTime = createdDateTime;
    }

    public AttendeeId AuthorId { get; private set; }

    public VenueId VenueId { get; private set; }

    public string Comment { get; private set; }

    public float RatingGiven { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public static VenueReview Create(AttendeeId authorId, VenueId venueId, string comment, float ratingGiven)
    {
        return new VenueReview(VenueReviewId.CreateUnique(), authorId, venueId, comment, ratingGiven,
            DateTime.UtcNow);
    }
}