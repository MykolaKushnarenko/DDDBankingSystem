using VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;
using VenueHosting.Module.Lessee.Domain.LesseeReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Lessee.Domain.LesseeReview;

public class LesseeReview : AggregateRote<LesseeReviewId, Guid>
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