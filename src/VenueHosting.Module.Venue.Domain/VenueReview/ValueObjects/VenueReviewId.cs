using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;

public sealed class VenueReviewId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private VenueReviewId()
    {
    }

    private VenueReviewId(Guid value)
    {
        Value = value;
    }

    public static VenueReviewId CreateUnique()
    {
        return new VenueReviewId(Guid.NewGuid());
    }

    public static VenueReviewId Create(Guid value)
    {
        return new VenueReviewId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}