using MediatR;

namespace VenueHosting.Module.Place.Application.Features.Place.GetAllPlaces;

public record PlaceQuery : IRequest<IReadOnlyList<VenueHosting.Domain.Place.Place>>;