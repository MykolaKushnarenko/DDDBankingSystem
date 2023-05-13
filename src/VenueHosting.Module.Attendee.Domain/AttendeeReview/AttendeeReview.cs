using VenueHosting.Module.Attendee.Domain.Attendee.ValueObjects;
using VenueHosting.Module.Attendee.Domain.AttendeeReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Attendee.Domain.AttendeeReview;

public sealed class AttendeeReview : AggregateRote<AttendeeReviewId, Guid>
{
    private AttendeeReview()
    {
    }

    private AttendeeReview(AttendeeReviewId id, AttendeeId attendeeId, VenueId venueId, LesseeId authorId,
        string comment, float ratingGiven,
        DateTime createdDateTime) : base(id)
    {
        AttendeeId = attendeeId;
        VenueId = venueId;
        AuthorId = authorId;
        Comment = comment;
        RatingGiven = ratingGiven;
        CreatedDateTime = createdDateTime;
    }

    public AttendeeId AttendeeId { get; private set; }

    public VenueId VenueId { get; private set; }

    public LesseeId AuthorId { get; private set; }

    public string Comment { get; private set; }

    public float RatingGiven { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public static AttendeeReview Create(AttendeeId attendeeId, VenueId venueId, LesseeId authorId, string comment,
        float ratingGiven)
    {
        return new AttendeeReview(AttendeeReviewId.CreateUnique(), attendeeId, venueId, authorId, comment, ratingGiven,
            DateTime.UtcNow);
    }
}