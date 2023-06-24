using MediatR;

namespace VenueHosting.Module.Place.Application.Features.Place.GetAllPlaces;

public record PlaceQuery : IRequest<IReadOnlyList<Domain.Place.Place>>;