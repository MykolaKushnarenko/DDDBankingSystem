using Component.Domain.Models;
using Component.Domain.Services;
using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.BusinessRules;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place;
using VenueHosting.Module.Venue.Domain.Replicas.User;
using VenueHosting.SharedKernel.Common.DomainEvents;

namespace VenueHosting.Module.Venue.Domain.Services;

public class VenueDomainService : DomainService
{
    public VenueDomainService(DomainEventCollector eventCollector) : base(eventCollector)
    {
    }

    public Aggregates.Venue.Venue Create(Id<Aggregates.Venue.Venue>? venueId,
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

        var venue = new Aggregates.Venue.Venue(
            hostId, placeId, eventName,
            description, capacity, visibility, startAtDateTime, endAtDateTime);

        EventCollector.AddDomainEvent(new VenueCreatedDomainEvent(venue.Id.Value, venue.Capacity));

        return venue;
    }

    public void AddActivity(Aggregates.Venue.Venue venue, string name, string description)
    {
        var activity = new Activity(name, description);

        CheckRule(new VenueActivityMustNotContainDuplicateBusinessRule(venue.Activities.ToHashSet(), activity));

        venue.AddActivity(activity);
    }

    public void MarkAsPublic(Aggregates.Venue.Venue venue)
    {
        venue.MakePublic();
    }
}