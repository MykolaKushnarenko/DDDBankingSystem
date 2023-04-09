namespace VenueHosting.Domain.VenueReview.ValueObjects;

public record VenueReviewId(Guid Value)
{
    public static VenueReviewId CreateUnique()
    {
        return new VenueReviewId(Guid.NewGuid());
    }

    public static VenueReviewId Create(Guid value)
    {
        return new VenueReviewId(value);
    }
}