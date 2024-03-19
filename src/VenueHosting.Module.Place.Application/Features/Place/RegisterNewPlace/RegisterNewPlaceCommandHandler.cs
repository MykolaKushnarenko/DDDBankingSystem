using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Place.Application.Common.Persistence;
using VenueHosting.Module.Place.Domain.Place.Entities;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Application.Features.Place.RegisterNewPlace;

internal sealed class RegisterNewPlaceCommandHandler : IRequestHandler<RegisterNewPlaceCommand, Domain.Place.Place>
{
    private readonly IPlaceStore _placeStore;

    public RegisterNewPlaceCommandHandler(IPlaceStore placeStore)
    {
        _placeStore = placeStore;
    }

    public async Task<Domain.Place.Place> Handle(RegisterNewPlaceCommand request, CancellationToken cancellationToken)
    {
        Domain.Place.Place place = Domain.Place.Place.Create(request.OwnerId,
            new Address(request.AddressCommand.Country, request.AddressCommand.City, request.AddressCommand.Street,
                request.AddressCommand.Number));

        List<Facility> facility =
            request.FacilityCommand.ConvertAll(x => Facility.Create(x.Name, x.Description, x.Quantity));

        place.AddFacilities(facility);

        await _placeStore.AddAsync(place);

        return place;
    }
}