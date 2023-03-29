using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Guest.ValueObjects;
using VenueHosting.Domain.Menu.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;

namespace VenueHosting.Domain.Guest;

public sealed class Guest : AggregateRote<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuId> _menuReviewIds = new();
    private readonly List<RatingId> _ratingIds = new();

    private Guest(GuestId id, string firstName, string lastName, string profileImage, AverageRating averageRating,
        UserId userId, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public UserId UserId { get; private set; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();

    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<MenuId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public IReadOnlyList<RatingId> RatingIds => _ratingIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Guest Create(string firstName, string lastName, string profileImage, AverageRating averageRating,
        UserId userId)
    {
        return new Guest(GuestId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId,
            DateTime.UtcNow, DateTime.UtcNow);
    }
}