using MediatR;
using VenueHosting.Module.Venue.Application.Extensions;
using VenueHosting.Module.Venue.Domain.Repositories;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

internal sealed class VenueQueryHandler : IRequestHandler<VenueQuery, Domain.Aggregates.VenueAggregate.Venue?>
{
    private readonly IVenueRepository _venue;

    public VenueQueryHandler(IVenueRepository venue)
    {
        _venue = venue;
    }

    public async Task<Domain.Aggregates.VenueAggregate.Venue?> Handle(VenueQuery request,
        CancellationToken cancellationToken)
    {
        return await _venue.FindOneOrThrowAsync(request.VenueId, cancellationToken);
    }
}