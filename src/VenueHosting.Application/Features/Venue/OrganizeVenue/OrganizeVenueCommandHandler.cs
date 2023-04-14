using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;

namespace VenueHosting.Application.Features.Venue.OrganizeVenue;

public class OrganizeVenueCommandHandler : IRequestHandler<OrganizeVenueCommand, Domain.Venue.Venue>
{
    private readonly IVenueStore _venueStore;
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScope _atomicScope;

    public OrganizeVenueCommandHandler(IVenueStore venueStore, IAtomicScope atomicScopeFactory, IPlaceStore placeStore)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScopeFactory;
        _placeStore = placeStore;
    }

    public async Task<Domain.Venue.Venue> Handle(OrganizeVenueCommand request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue venue = Domain.Venue.Venue.Create(
            request.ownerId,
            request.lesseeId,
            request.placeId,
            request.eventName,
            request.description,
            request.isPublic,
            request.startAtDateTime,
            request.endAtDateTime);

        await _venueStore.AddAsync(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return venue;
    }
}