using MediatR;

namespace VenueHosting.Application.Features.Place.GetAllPlaces;

public record PlaceQuery : IRequest<IReadOnlyList<Domain.Place.Place>>;