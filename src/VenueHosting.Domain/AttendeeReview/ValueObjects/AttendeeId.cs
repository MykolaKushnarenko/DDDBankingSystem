
namespace VenueHosting.Domain.AttendeeReview.ValueObjects;

public record AttendeeReviewId(Guid Value)
{
    public static AttendeeReviewId CreateUnique()
    {
        return new AttendeeReviewId(Guid.NewGuid());
    }
}