using Component.Domain.Models;
using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.PlaceAggregate;
using VenueHosting.Module.Venue.Domain.Replicas.UserAggregate;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

public class OrganizeVenueCommand : IRequest<Domain.Aggregates.VenueAggregate.Venue>
{
    public OrganizeVenueCommand(
        Guid hostId,
        Guid placeId,
        string eventName,
        string description,
        int capacity,
        Visibility visibility,
        DateTime startAtDateTime,
        DateTime endAtDateTime)
    {
        HostId = new Id<User>(hostId);
        PlaceId = new Id<Place>(placeId);
        EventName = eventName;
        Description = description;
        Capacity = capacity;
        Visibility = visibility;
        StartAtDateTime = startAtDateTime;
        EndAtDateTime = endAtDateTime;
    }

    public Id<User> HostId { get; init; }
    public Id<Place> PlaceId { get; init; }
    public string EventName { get; init; }
    public string Description { get; init; }
    public int Capacity { get; init; }
    public Visibility Visibility { get; init; }
    public DateTime StartAtDateTime { get; init; }
    public DateTime EndAtDateTime { get; init; }
}