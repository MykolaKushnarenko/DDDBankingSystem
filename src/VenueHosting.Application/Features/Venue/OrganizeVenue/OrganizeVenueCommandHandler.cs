using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Application.Common.Specifications;

namespace VenueHosting.Application.Features.Venue.OrganizeVenue;

internal sealed class OrganizeVenueCommandHandler : IRequestHandler<OrganizeVenueCommand, Domain.Venue.Venue>
{
    private readonly IVenueStore _venueStore;
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScope _atomicScope;

    public OrganizeVenueCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope, IPlaceStore placeStore)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
        _placeStore = placeStore;
    }

    public async Task<Domain.Venue.Venue> Handle(OrganizeVenueCommand request, CancellationToken cancellationToken)
    {
        bool placeExist = await _placeStore.CheckIfPlaceExistAsync(new FindPlaceByPlaceIdSpecification(request.PlaceId),
            cancellationToken);

        if (!placeExist)
        {
            throw new ArgumentException("Place doesn't exist.");
        }

        Domain.Venue.Venue venue = Domain.Venue.Venue.Create(
            request.OwnerId,
            request.LesseeId,
            request.PlaceId,
            request.EventName,
            request.Description,
            request.IsPublic,
            request.StartAtDateTime,
            request.EndAtDateTime);

        await _venueStore.AddAsync(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return venue;
    }
}