using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Attendee.Domain.AttendeeReview.ValueObjects;

public sealed class AttendeeReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private AttendeeReviewId()
    {
    }

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