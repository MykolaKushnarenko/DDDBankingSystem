using Component.Domain.Models;
using MediatR;

namespace VenueHosting.Module.Place.Application.Features.Place.GetPlace;

public class GetPlaceQuery : IRequest<Domain.Place.Place>
{
    public GetPlaceQuery(Guid placeId)
    {
        PlaceId = new Id<Domain.Place.Place>(placeId);
    }

    public Id<Domain.Place.Place> PlaceId { get; init; }
}