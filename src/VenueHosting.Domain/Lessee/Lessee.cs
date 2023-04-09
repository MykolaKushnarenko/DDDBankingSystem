using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.LesseeReview.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.Lessee;

public class Lessee : AggregateRote<LesseeId>
{
    private List<LesseeReviewId> _lesseeReviewIds = new();

    private List<VenueId> _venueIds = new();

    private Lessee()
    {
    }

    private Lessee(LesseeId id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<LesseeReviewId> LesseeReviewIds => _lesseeReviewIds.AsReadOnly();

    public IReadOnlyList<VenueId> VenueIds => _venueIds.AsReadOnly();

    public static Lessee Create(UserId userId)
    {
        return new Lessee(LesseeId.CreateUnique(), userId);
    }
}