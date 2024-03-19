using Component.Domain.Models;
using JetBrains.Annotations;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate;
using VenueHosting.Module.Venue.Domain.Replicas.UserAggregate;

namespace VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate;

public sealed class Venue : AggregateRote<Venue>
{
    private readonly List<Activity> _activities = new();
    private readonly List<PartnerReference> _partners = new();
    private readonly List<Amenity> _amenities = new();

    [UsedImplicitly]
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

    public Id<User> HostId { get; private set; } = null!;

    public Id<Place> PlaceId { get; private set; } = null!;

    public Schedule Schedule { get; private set; } = null!;

    public string Description { get; private set; } = null!;

    public string EventName { get; private set; } = null!;

    public Visibility Visibility { get; private set; }

    public VenueStatus VenueStatus { get; private set; }

    public IReadOnlyList<Activity> Activities => _activities.ToArray();

    public IReadOnlyList<PartnerReference> Partners => _partners.ToArray();

    public IReadOnlyList<Amenity> Amenities => _amenities.ToArray();

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