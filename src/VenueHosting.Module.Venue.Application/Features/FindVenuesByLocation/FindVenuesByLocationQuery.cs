using MediatR;

namespace VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;

public record FindVenuesByLocationQuery(string Country, string City, string Street) : IRequest<IReadOnlyList<Domain.Aggregates.VenueAggregate.Venue>>;