using MediatR;
using VenueHosting.Module.Place.Application.Common.Interfaces;
using VenueHosting.Module.Place.Application.Common.Persistence;

namespace VenueHosting.Module.Place.Application.Features.Place.GetAllPlaces;

internal sealed class PlaceQueryHandler : IRequestHandler<PlaceQuery, IReadOnlyList<Domain.Place.Place>>
{
    private readonly IAtomicScopeFactory _atomicScopeFactory;
    private readonly IPlaceStore _placeStore;

    public PlaceQueryHandler(IPlaceStore placeStore, IAtomicScopeFactory atomicScopeFactory)
    {
        _placeStore = placeStore;
        _atomicScopeFactory = atomicScopeFactory;
    }

    public async Task<IReadOnlyList<Domain.Place.Place>> Handle(PlaceQuery request, CancellationToken cancellationToken)
    {
        await using IAtomicScope atomicScope = _atomicScopeFactory.CreateScope();
        IReadOnlyList<Domain.Place.Place> places = await _placeStore.FetchAllAsync(atomicScope);

        await atomicScope.CommitAsync(cancellationToken);
        return places;
    }
}