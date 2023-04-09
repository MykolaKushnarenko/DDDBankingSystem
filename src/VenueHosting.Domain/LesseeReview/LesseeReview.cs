using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.LesseeReview.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.LesseeReview;

public class LesseeReview : AggregateRote<LesseeReviewId>
{
    private LesseeReview()
    {
    }

    private LesseeReview(LesseeReviewId id, AttendeeId authorId, LesseeId lesseeId, VenueId venueId, string comment, float ratingGiven,
        DateTime createdDateTime) : base(id)
    {
        AuthorId = authorId;
        VenueId = venueId;
        LesseeId = lesseeId;
        Comment = comment;
        RatingGiven = ratingGiven;
        CreatedDateTime = createdDateTime;
    }

    public AttendeeId AuthorId { get; private set; }

    public LesseeId LesseeId { get; private set; }

    public VenueId VenueId { get; private set; }

    public string Comment { get; private set; }

    public float RatingGiven { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public static LesseeReview Create(AttendeeId authorId, LesseeId lesseeId, VenueId venueId, string comment,
        float ratingGiven)
    {
        return new LesseeReview(LesseeReviewId.CreateUnique(), authorId, lesseeId, venueId, comment, ratingGiven,
            DateTime.UtcNow);
    }
}