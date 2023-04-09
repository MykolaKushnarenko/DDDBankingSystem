
using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.AttendeeReview.ValueObjects;

public class AttendeeReviewId : ValueObject
{
    public Guid Value { get; private set; }

    private AttendeeReviewId(){}

    private AttendeeReviewId(Guid value)
    {
        Value = value;
    }

    public static AttendeeReviewId CreateUnique()
    {
        return new AttendeeReviewId(Guid.NewGuid());
    }

    public static AttendeeReviewId Create(Guid value)
    {
        return new AttendeeReviewId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}