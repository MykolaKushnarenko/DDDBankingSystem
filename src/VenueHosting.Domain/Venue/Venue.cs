using VenueHosting.Domain.Attendee.ValueObjects;
using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Reservation.ValueObjects;
using VenueHosting.Domain.Venue.DomainEvents;
using VenueHosting.Domain.Venue.Entities;
using VenueHosting.Domain.Venue.ValueObjects;
using VenueHosting.Domain.VenueReview.ValueObjects;

namespace VenueHosting.Domain.Venue;

public class Venue : AggregateRote<VenueId, Guid>
{
    private List<Activity> _activities = new();

    private List<VenueReviewId> _venueReviewIds = new();

    private List<ReservationId> _reservationIds = new();

    private Venue()
    {
    }

    private Venue(
        VenueId venueId,
        OwnerId ownerId,
        LesseeId lesseeId,
        PlaceId placeId,
        string eventName,
        string description,
        bool isPublic,
        DateTime startAtDateTime,
        DateTime endAtDateTime,
        DateTime createdAtDateTime,
        DateTime updatedAtDateTime) : base(venueId)
    {
        OwnerId = ownerId;
        LesseeId = lesseeId;
        PlaceId = placeId;
        EventName = eventName;
        Description = description;
        IsPublic = isPublic;
        StartAtDateTime = startAtDateTime;
        EndAtDateTime = endAtDateTime;
        CreatedAtDateTime = createdAtDateTime;
        UpdatedAtDateTime = updatedAtDateTime;

        AddDomainEvent(new VenueOrganizedDomainEvent(venueId, PlaceId, LesseeId));
    }

    public OwnerId OwnerId { get; private set; }

    public LesseeId LesseeId { get; private set; }

    public PlaceId PlaceId { get; private set; }

    //TODO: Add partners

    public string Description { get; private set; }

    public string EventName { get; private set; }

    public bool IsPublic { get; private set; }

    public IReadOnlyList<Activity> Activities => _activities.ToList().AsReadOnly();

    public IReadOnlyList<VenueReviewId> VenueReviewIds => _venueReviewIds.ToList().AsReadOnly();

    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.ToList().AsReadOnly();

    public DateTime StartAtDateTime { get; private set; }

    public DateTime EndAtDateTime { get; private set; }

    public DateTime CreatedAtDateTime { get; private set; }

    public DateTime UpdatedAtDateTime { get; private set; }

    public static Venue Organize(
        OwnerId ownerId,
        LesseeId lesseeId,
        PlaceId placeId,
        string eventName,
        string description,
        bool isPublic,
        DateTime startAtDateTime,
        DateTime endAtDateTime)
    {
        return new Venue(VenueId.CreateUnique(),
            ownerId,
            lesseeId,
            placeId,
            eventName,
            description,
            isPublic,
            startAtDateTime,
            endAtDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddActivity(Activity activity)
    {
        //TODO: validation

        _activities.Add(activity);

        UpdatedAtDateTime = DateTime.UtcNow;
    }

    public void MakeEvenAsPrivate()
    {
        IsPublic = false;
    }

    public void MakeEvenAsPublic()
    {
        IsPublic = true;
    }

    public void AddANewReservationId(ReservationId reservationId)
    {
        _reservationIds.Add(reservationId);
    }

    public void AddANewReview(VenueReviewId venueReviewId)
    {
        _venueReviewIds.Add(venueReviewId);
    }

    public void UpdateEventGeneralInformation(string eventName, string description)
    {
        //validation

        EventName = eventName;
        Description = description;
    }
}