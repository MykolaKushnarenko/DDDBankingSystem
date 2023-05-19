using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.DomainEvents;
using VenueHosting.Module.Venue.Domain.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.VenueReview.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Venue;

public class Venue : AggregateRote<VenueId, Guid>
{
    private readonly List<Activity> _activities = new();

    private readonly List<VenueReviewId> _venueReviewIds = new();

    private readonly List<ReservationId> _reservationIds = new();

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
        Status = VenueStatus.InPayment;
    }

    public OwnerId OwnerId { get; private set; }

    public LesseeId LesseeId { get; private set; }

    public PlaceId PlaceId { get; private set; }

    //TODO: Add partners

    public string Description { get; private set; }

    public string EventName { get; private set; }

    public bool IsPublic { get; private set; }

    public VenueStatus Status { get; private set; }

    public IReadOnlyList<Activity> Activities => _activities.ToList().AsReadOnly();

    public IReadOnlyList<VenueReviewId> VenueReviewIds => _venueReviewIds.ToList().AsReadOnly();

    public IReadOnlyList<ReservationId> ReservationIds => _reservationIds.ToList().AsReadOnly();

    public DateTime StartAtDateTime { get; private set; }

    public DateTime EndAtDateTime { get; private set; }

    public DateTime CreatedAtDateTime { get; private set; }

    public DateTime UpdatedAtDateTime { get; private set; }

    public static Venue Create(
        OwnerId ownerId,
        LesseeId lesseeId,
        PlaceId placeId,
        string eventName,
        string description,
        bool isPublic,
        DateTime startAtDateTime,
        DateTime endAtDateTime)
    {
        VenueId id = VenueId.CreateUnique();

        var venue = new Venue(VenueId.CreateUnique(),
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

        venue.AddDomainEvent(new VenueOrganizedDomainEvent(id.Value, venue.LesseeId.Value));

        return venue;
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

    public void AddNewReservation(ReservationId reservationId)
    {
        _reservationIds.Add(reservationId);
    }

    public void AddNewReview(VenueReviewId venueReviewId)
    {
        _venueReviewIds.Add(venueReviewId);
    }

    public void UpdateEventGeneralInformation(string eventName, string description)
    {
        //validation

        EventName = eventName;
        Description = description;
    }

    public void Organize()
    {
        Status = VenueStatus.Organized;
    }
}