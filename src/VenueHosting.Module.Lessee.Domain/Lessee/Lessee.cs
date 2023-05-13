using VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;
using VenueHosting.Module.Lessee.Domain.LesseeReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Lessee.Domain.Lessee;

public class Lessee : AggregateRote<LesseeId, Guid>
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

    public void AddRegisteredVenue(VenueId venueId)
    {
        _venueIds.Add(venueId);
    }
}