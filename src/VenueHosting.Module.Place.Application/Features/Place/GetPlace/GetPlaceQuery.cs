using MediatR;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Application.Features.Place.GetPlace;

public class GetPlaceQuery : IRequest<Domain.Place.Place>
{
    public PlaceId PlaceId { get; init; }
}