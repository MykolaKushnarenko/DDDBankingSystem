using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.Module.Venue.Application.Features.OrganizeVenue;

public record OrganizeVenueCommand(
    Id<Domain.Replicas.User.User> HostId,
    Id<Domain.Replicas.Place.Place> PlaceId,
    string EventName,
    string Description,
    int Capacity,
    Visibility Visibility,
    DateTime StartAtDateTime,
    DateTime EndAtDateTime) : IRequest<Domain.Aggregates.Venue.Venue>;