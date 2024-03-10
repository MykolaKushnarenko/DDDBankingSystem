using Component.Domain.Models;
using MediatR;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

public sealed record VenueQuery(Id<Domain.Aggregates.Venue.Venue> VenueId) : IRequest<Domain.Aggregates.Venue.Venue?>;