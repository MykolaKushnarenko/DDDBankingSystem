using MediatR;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.Features.Venue;

public sealed record VenueQuery(VenueId VenueId) : IRequest<Domain.Venue.Venue>;