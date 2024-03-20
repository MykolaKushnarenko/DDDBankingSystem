using MediatR;
using VenueHosting.Module.Venue.Domain.Specifications.VenueAggregate;
using VenueHosting.Module.Venue.Domain.Stores;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

internal sealed class VenueQueryHandler : IRequestHandler<VenueQuery, Domain.Aggregates.VenueAggregate.Venue?>
{
    private readonly IVenueStore _venue;

    public VenueQueryHandler(IVenueStore venue)
    {
        _venue = venue;
    }

    public async Task<Domain.Aggregates.VenueAggregate.Venue?> Handle(VenueQuery request,
        CancellationToken cancellationToken)
    {
        var venue = await _venue.FindOneAsync(VenueByVenueIdSpec.Create(request.VenueId), cancellationToken);

        return venue;
    }
}