using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.AttendeeReview.ValueObjects;
using VenueHosting.Domain.Bill.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Reservation.ValueObjects;
using VenueHosting.Domain.User.ValueObjects;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Domain.Attendee;

public class Attendee : AggregateRote<AttendeeId>
{
    private List<AttendeeReviewId> _attendeeReviewIds = new();
    private List<BillId> _billIds = new();
    private List<ReservationId> _reservationIds = new();
    private List<VenueId> _venueIds = new();

    private Attendee()
    {
    }

    private Attendee(AttendeeId id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public UserId UserId { get; private set; }

    public IReadOnlyList<AttendeeReviewId> AttendeeReviewIds => _attendeeReviewIds.AsReadOnly();

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();

    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.AsReadOnly();

    public IReadOnlyList<VenueId> VenueIds => _venueIds.AsReadOnly();

    public static Attendee Create(UserId userId)
    {
        return new Attendee(AttendeeId.CreateUnique(), userId);
    }
}