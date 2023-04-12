using MediatR;
using VenueHosting.Application.Common.Persistence;

namespace VenueHosting.Application.Features.Venue;

internal sealed class VenueQueryHandler : IRequestHandler<VenueQuery, Domain.Venue.Venue>
{
    private readonly IVenueStore _venue;

    public VenueQueryHandler(IVenueStore venue)
    {
        _venue = venue;
    }

    public async Task<Domain.Venue.Venue> Handle(VenueQuery request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venue.FetchVenueByIdAsync(request.VenueId);

        return venue;
    }
}