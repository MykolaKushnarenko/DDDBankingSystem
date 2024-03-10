using Component.Domain.Models;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place;
using VenueHosting.Module.Venue.Domain.Replicas.User;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue;

public sealed class Venue : AggregateRote<Venue>
{
    private readonly HashSet<Activity> _activities = new();
    private readonly HashSet<Partner.Partner> _partners = new ();

    private Venue()
    {
    }

    internal Venue(
        Id<User> hostId,
        Id<Place> placeId,
        string eventName,
        string description,
        int capacity,
        Visibility visibility,
        DateTime startAtDateTime,
        DateTime endAtDateTime,
        Id<Venue>? venueId = null) : base(venueId ?? Id<Venue>.CreateUnique())
    {
        PlaceId = placeId;
        HostId = hostId;
        EventName = eventName;
        Description = description;
        Visibility = visibility;
        StartAtDateTime = startAtDateTime;
        EndAtDateTime = endAtDateTime;
        VenueStatus = VenueStatus.Organized;
        Capacity = capacity;
    }

    public Id<User> HostId { get; private set; }

    public Id<Place> PlaceId { get; private set; }

    public Schedule Schedule { get; private set; }

    public string Description { get; private set; }

    public string EventName { get; private set; }

    public Visibility Visibility { get; private set; }

    public VenueStatus VenueStatus { get; private set; }

    public IReadOnlyList<Activity> Activities => _activities.ToList().AsReadOnly();
    public IReadOnlyList<Partner.Partner> Partners => _partners.ToList().AsReadOnly();

    public int Capacity { get; private set; }

    public DateTime StartAtDateTime { get; private set; }

    public DateTime EndAtDateTime { get; private set; }

    internal void AddActivity(Activity activity)
    {
        _activities.Add(activity);
    }

    internal void MakePublic()
    {
        Visibility = Visibility.Public;
    }

    internal void MakePrivate()
    {
        Visibility = Visibility.Public;
    }

    internal void Start()
    {
        VenueStatus = VenueStatus.Started;
    }

    internal void Cancel()
    {
        VenueStatus = VenueStatus.Cancelled;
    }

    internal void Finish()
    {
        VenueStatus = VenueStatus.Finished;
    }

    internal void UpdateDetails(string eventName, string description)
    {
        // CheckRule(new VenueEventNameMustNotExceedLengthBusinessRule(eventName));
        // CheckRule(new VenueDescriptionMustNotExceedLengthBusinessRule(description));

        EventName = eventName;
        Description = description;
    }
}