using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Venue;

public sealed class Venue : AggregateRote<VenueId, Guid>
{
    private readonly List<Activity> _activities = new();

    private readonly List<VenueReview.VenueReview> _venueReviews = new();

    private readonly List<Reservation.Reservation> _reservations = new();

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
        Visibility visibility,
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
        Visibility = visibility;
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

    public Visibility Visibility { get; private set; }

    public VenueStatus Status { get; private set; }

    public IReadOnlyList<Activity> Activities => _activities.ToList().AsReadOnly();

    public IReadOnlyList<VenueReview.VenueReview> VenueReviews => _venueReviews.ToList().AsReadOnly();

    public IReadOnlyList<Reservation.Reservation> Reservations => _reservations.ToList().AsReadOnly();

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
        Visibility visibility,
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
            visibility,
            startAtDateTime,
            endAtDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);

        venue.AddDomainEvent(new VenueCreatedIntegrationEvent(id.Value, venue.LesseeId.Value));

        return venue;
    }

    public void AddActivity(Activity activity)
    {
        //TODO: validation

        _activities.Add(activity);

        UpdatedAtDateTime = DateTime.UtcNow;
    }

    public void ChangeVisibility(Visibility visibility)
    {
        Visibility = visibility;
    }

    public void AddReview(VenueReview.VenueReview venueReview)
    {
        _venueReviews.Add(venueReview);
    }

    public void RemoveReview(VenueReview.VenueReview venueReview)
    {
        _venueReviews.Remove(venueReview);
    }

    public void UpdateDetails(string eventName, string description)
    {
        //validation

        EventName = eventName;
        Description = description;
    }

    public void Reserve(Reservation.Reservation reservation)
    {
        _reservations.Add(reservation);
    }

    public void CancelReservation(Reservation.Reservation reservation)
    {
        _reservations.Remove(reservation);
    }

    public void ChangeStatus(VenueStatus status)
    {
        Status = status;
    }
}