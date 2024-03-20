using Component.Domain.Models;
using Component.Domain.Services;
using VenueHosting.Contracts.Events;
using VenueHosting.Module.Venue.Domain.Aggregates.PlaceReplica;
using VenueHosting.Module.Venue.Domain.Aggregates.UserReplica;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.BusinessRules;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;
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
            description, capacity, visibility, 
            new Schedule(startAtDateTime, endAtDateTime));

        EventCollector.AddDomainEvent(new VenueCreatedDomainEvent(venue.Id.Value, venue.Capacity));

        return venue;
    }

    public Activity CreateActivity(string name, string description)
    {
        return new Activity(name, description);
    }
    
    public void AddActivity(VenueAggregate venue, Activity activity)
    {
        CheckRule(new VenueActivityMustNotContainDuplicateBusinessRule(venue.Activities.ToHashSet(), activity));

        venue.AddActivity(activity);
    }

    public void MarkAsPublic(VenueAggregate venue)
    {
        venue.MakePublic();
    }
}