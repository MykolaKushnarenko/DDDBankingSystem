using MediatR;
using VenueHosting.Module.Place.Application.Common.Interfaces;
using VenueHosting.Module.Place.Application.Common.Persistence;

namespace VenueHosting.Module.Place.Application.Features.Place.GetPlace;

internal sealed class GetPlaceHandler : IRequestHandler<GetPlaceQuery, Domain.Place.Place>
{
    private readonly IAtomicScopeFactory _atomicScopeFactory;
    private readonly IPlaceStore _placeStore;

    public GetPlaceHandler(IAtomicScopeFactory atomicScopeFactory, IPlaceStore placeStore)
    {
        _atomicScopeFactory = atomicScopeFactory;
        _placeStore = placeStore;
    }

    public async Task<Domain.Place.Place> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
    {
        await using IAtomicScope atomicScope = _atomicScopeFactory.CreateScope();

        Domain.Place.Place place = await _placeStore.FetchAsync(request.PlaceId, atomicScope);

        await atomicScope.CommitAsync(cancellationToken);

        return place;
    }
}