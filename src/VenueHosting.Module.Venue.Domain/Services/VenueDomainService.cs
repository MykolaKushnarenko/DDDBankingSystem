using Component.Domain.Models;
using Component.Domain.Services;
using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.BusinessRules;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate;
using VenueHosting.Module.Venue.Domain.Replicas.UserAggregate;
using VenueHosting.SharedKernel.Common.DomainEvents;
using VenueAggregate = VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Venue;

namespace VenueHosting.Module.Venue.Domain.Services;

public class VenueDomainService : DomainService
{
    public VenueDomainService(DomainEventCollector eventCollector) : base(eventCollector)
    {
    }

    public Aggregates.VenueAggregate.Venue Create(Id<Aggregates.VenueAggregate.Venue>? venueId,
        Id<User> hostId,
        Id<Place> placeId,
        string eventName,
        string description,
        int capacity,
        Visibility visibility,
        DateTime startAtDateTime,
        DateTime endAtDateTime)
    {
        CheckRule(new VenueEventNameMustNotExceedLengthBusinessRule(eventName));
        CheckRule(new VenueDescriptionMustNotExceedLengthBusinessRule(description));

        var venue = new Aggregates.VenueAggregate.Venue(
            hostId, placeId, eventName,
            description, capacity, visibility, new Schedule(startAtDateTime, endAtDateTime));

        EventCollector.AddDomainEvent(new VenueCreatedDomainEvent(venue.Id.Value, venue.Capacity));

        return venue;
    }

    public void AddActivity(VenueAggregate venue, string name, string description)
    {
        var activity = new Activity(name, description);

        CheckRule(new VenueActivityMustNotContainDuplicateBusinessRule(venue.Activities.ToHashSet(), activity));

        venue.AddActivity(activity);
    }

    public void MarkAsPublic(VenueAggregate venue)
    {
        venue.MakePublic();
    }
}