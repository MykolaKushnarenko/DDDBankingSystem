using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;

namespace VenueHosting.Module.Venue.Application.Features.FetchVenue;

internal sealed class VenueQueryHandler : IRequestHandler<VenueQuery, Domain.Venue.Venue?>
{
    private readonly IVenueStore _venue;

    public VenueQueryHandler(IVenueStore venue)
    {
        _venue = venue;
    }

    public async Task<Domain.Venue.Venue?> Handle(VenueQuery request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venue.FetchVenueByIdAsync(request.VenueId);

        return venue;
    }
}