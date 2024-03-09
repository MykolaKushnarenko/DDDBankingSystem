using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

public sealed record VenueQuery(Id<Domain.Aggregates.Venue.Venue> VenueId) : IRequest<Domain.Aggregates.Venue.Venue?>;