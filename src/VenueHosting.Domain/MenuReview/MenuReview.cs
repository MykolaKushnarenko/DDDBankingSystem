using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Guest.ValueObjects;
using VenueHosting.Domain.Host.ValueObjects;
using VenueHosting.Domain.Menu.ValueObjects;
using VenueHosting.Domain.MenuReview.ValueObjects;

namespace VenueHosting.Domain.MenuReview;

public sealed class MenuReview : AggregateRote<MenuReviewId>
{
    private MenuReview(MenuReviewId id, float rating, string comment, HostId hostId, MenuId menuId, GuestId guestId,
        DinnerId dinnerId, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public float Rating { get; private set; }

    public string Comment { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public GuestId GuestId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static MenuReview Create(float rating, string comment, HostId hostId, MenuId menuId, GuestId guestId,
        DinnerId dinnerId)
    {
        return new MenuReview(MenuReviewId.CreateUnique(), rating, comment, hostId, menuId, guestId, dinnerId,
            DateTime.UtcNow, DateTime.UtcNow);
    }
}