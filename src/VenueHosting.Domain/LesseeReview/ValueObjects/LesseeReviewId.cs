namespace VenueHosting.Domain.LesseeReview.ValueObjects;

public sealed record LesseeReviewId(Guid Value)
{
    public static LesseeReviewId CreateUnique()
    {
        return new LesseeReviewId(Guid.NewGuid());
    }
}