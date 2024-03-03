using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

public sealed record VenueQuery(VenueId VenueId) : IRequest<Domain.Aggregates.Venue.Venue?>;