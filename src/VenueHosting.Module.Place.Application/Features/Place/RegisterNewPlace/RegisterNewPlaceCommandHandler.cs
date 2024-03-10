using Component.Persistence.SqlServer.AtomicScope;
using MediatR;
using VenueHosting.Module.Place.Application.Common.Persistence;
using VenueHosting.Module.Place.Domain.Place.Entities;
using VenueHosting.Module.Place.Domain.Place.ValueObjects;

namespace VenueHosting.Module.Place.Application.Features.Place.RegisterNewPlace;

internal sealed class RegisterNewPlaceCommandHandler : IRequestHandler<RegisterNewPlaceCommand, Domain.Place.Place>
{
    private readonly IPlaceStore _placeStore;
    private readonly IAtomicScopeFactory _atomicScopeFactory;

    public RegisterNewPlaceCommandHandler(IPlaceStore placeStore, IAtomicScopeFactory atomicScopeFactory)
    {
        _placeStore = placeStore;
        _atomicScopeFactory = atomicScopeFactory;
    }

    public async Task<Domain.Place.Place> Handle(RegisterNewPlaceCommand request, CancellationToken cancellationToken)
    {
        await using IAtomicScope atomicScope = _atomicScopeFactory.CreateAtomicScope();

        Domain.Place.Place place = Domain.Place.Place.Create(request.OwnerId,
            new Address(request.AddressCommand.Country, request.AddressCommand.City, request.AddressCommand.Street,
                request.AddressCommand.Number));

        List<Facility> facility =
            request.FacilityCommand.ConvertAll(x => Facility.Create(x.Name, x.Description, x.Quantity));

        place.AddFacilities(facility);

        await _placeStore.AddAsync(place, atomicScope);
        await atomicScope.CommitAsync(cancellationToken);

        return place;
    }
}