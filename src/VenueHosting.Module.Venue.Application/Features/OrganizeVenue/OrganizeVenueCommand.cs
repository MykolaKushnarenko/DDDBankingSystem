using Component.Domain.Models;
using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

public class OrganizeVenueCommand : IRequest<Domain.Aggregates.Venue.Venue>
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
        HostId = new Id<Domain.Replicas.User.User>(hostId);
        PlaceId = new Id<Domain.Replicas.Place.Place>(placeId);
        EventName = eventName;
        Description = description;
        Capacity = capacity;
        Visibility = visibility;
        StartAtDateTime = startAtDateTime;
        EndAtDateTime = endAtDateTime;
    }

    public Id<Domain.Replicas.User.User> HostId { get; init; }
    public Id<Domain.Replicas.Place.Place> PlaceId { get; init; }
    public string EventName { get; init; }
    public string Description { get; init; }
    public int Capacity { get; init; }
    public Visibility Visibility { get; init; }
    public DateTime StartAtDateTime { get; init; }
    public DateTime EndAtDateTime { get; init; }
}