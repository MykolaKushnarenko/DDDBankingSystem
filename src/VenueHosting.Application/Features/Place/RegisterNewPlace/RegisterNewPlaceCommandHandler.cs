using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Domain.Place.Entities;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Application.Features.Place.RegisterNewPlace;

internal sealed class RegisterNewPlaceCommandHandler : IRequestHandler<RegisterNewPlaceCommand, Domain.Place.Place>
{
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScope _atomicScope;

    public RegisterNewPlaceCommandHandler(IPlaceStore placeStore, IAtomicScope atomicScope)
    {
        _placeStore = placeStore;
        _atomicScope = atomicScope;
    }

    public async Task<Domain.Place.Place> Handle(RegisterNewPlaceCommand request, CancellationToken cancellationToken)
    {
        var place = Domain.Place.Place.Create(request.OwnerId,
            new Address(request.AddressCommand.Country, request.AddressCommand.City, request.AddressCommand.Street,
                request.AddressCommand.Number));

        List<Facility> facility =
            request.FacilityCommand.ConvertAll(x => Facility.Create(x.Name, x.Description, x.Quantity));

        place.AddExistingFacilities(facility);

        await _placeStore.AddAsync(place, cancellationToken);
        await _atomicScope.CommitAsync(cancellationToken);

        return place;
    }
}