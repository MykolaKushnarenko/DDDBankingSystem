using VenueHosting.Domain.Common.Models;

namespace VenueHosting.Domain.LesseeReview.ValueObjects;

public sealed class LesseeReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private LesseeReviewId(){}

    private LesseeReviewId(Guid value)
    {
        Value = value;
    }

    public static LesseeReviewId CreateUnique()
    {
        return new LesseeReviewId(Guid.NewGuid());
    }

    public static LesseeReviewId Create(Guid value)
    {
        return new LesseeReviewId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}