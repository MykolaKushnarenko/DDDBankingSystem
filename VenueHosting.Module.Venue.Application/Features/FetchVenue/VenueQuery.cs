using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

public sealed record VenueQuery(VenueId VenueId) : IRequest<Domain.Venue.Venue>;