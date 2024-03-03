using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue;

public sealed class Venue : AggregateRote<VenueId, Guid>
{
    private readonly List<Activity> _activities = new();

    private readonly List<VenueReview> _venueReviews = new();

    private readonly List<Reservation> _reservations = new();

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

    public IReadOnlyList<VenueReview> VenueReviews => _venueReviews.ToList().AsReadOnly();

    public IReadOnlyList<Reservation> Reservations => _reservations.ToList().AsReadOnly();

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
        var id = VenueId.CreateUnique();
        var venue = new Venue(
            id,
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

        venue.CheckRule(new VenueEventNameMustNotExceedLengthBusinessRule(venue.EventName));
        venue.CheckRule(new VenueDescriptionMustNotExceedLengthBusinessRule(venue.Description));

        venue.AddDomainEvent(new VenueCreatedIntegrationEvent(id.Value, venue.LesseeId.Value));

        return venue;
    }

    public void AddActivity(Activity activity)
    {
        CheckRule(new VenueActivityMustNotContainDuplicateBusinessRule(_activities, activity));

        _activities.Add(activity);

        //Check for internal clock
        UpdatedAtDateTime = DateTime.UtcNow;
    }

    public void ChangeVisibility(Visibility visibility)
    {
        Visibility = visibility;
    }

    public void ChangeStatus(VenueStatus status)
    {
        Status = status;
    }

    public void AddReview(VenueReview venueReview)
    {
        CheckRule(new VenueReviewMustNotContainDuplicateBusinessRule(_venueReviews, venueReview));

        _venueReviews.Add(venueReview);
    }

    public void UpdateReview(VenueReview venueReview)
    {
        CheckRule(new VenueReviewMustExistBusinessRule(_venueReviews, venueReview));

        VenueReview oldVenueReview = _venueReviews.Find(x => x.Id == venueReview.Id)!;
        _venueReviews.Remove(oldVenueReview);

        _venueReviews.Add(venueReview);
    }

    public void RemoveReview(VenueReview venueReview)
    {
        CheckRule(new VenueReviewMustExistBusinessRule(_venueReviews, venueReview));

        _venueReviews.Remove(venueReview);
    }

    public void UpdateDetails(string eventName, string description)
    {
        CheckRule(new VenueEventNameMustNotExceedLengthBusinessRule(eventName));
        CheckRule(new VenueDescriptionMustNotExceedLengthBusinessRule(description));

        EventName = eventName;
        Description = description;
    }

    public void ReserveSpot(Reservation reservation)
    {
        CheckRule(new VenueReservationMustNotAlreadyExistBusinessRule(_reservations, reservation));

        _reservations.Add(reservation);
    }

    public void CancelReservation(ReservationId reservationId)
    {
        var soughtReservation = _reservations.Find(x => x.Id == reservationId);

        if (soughtReservation is null)
        {
            throw new VenueReservationNotFoundException();
        }

        _reservations.Remove(soughtReservation);
    }
}