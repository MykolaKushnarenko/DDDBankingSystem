using MediatR;

namespace VenueHosting.Application.Features.Venue.FindVenuesByLocation;

public record FindVenuesByLocationQuery(string Country, string City, string Street) : IRequest<IReadOnlyList<Domain.Venue.Venue>>;