using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Place.Application.Common.Persistence;

namespace VenueHosting.Module.Place.Application.Features.Place.GetPlace;

internal sealed class GetPlaceHandler : IRequestHandler<GetPlaceQuery, Domain.Place.Place>
{
    private readonly IPlaceStore _placeStore;

    public GetPlaceHandler(IPlaceStore placeStore)
    {
        _placeStore = placeStore;
    }

    public async Task<Domain.Place.Place> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
    {
        Domain.Place.Place place = await _placeStore.FetchAsync(request.PlaceId);

        return place;
    }
}