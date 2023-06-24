using MediatR;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;

namespace VenueHosting.Module.Place.Application.Features.Place.RegisterNewPlace;

public record RegisterNewPlaceCommand(OwnerId OwnerId, AddressCommand AddressCommand,
    List<FacilityCommand> FacilityCommand) : IRequest<Domain.Place.Place>;

public record AddressCommand(string Country, string City, string Street, int Number);

public record FacilityCommand(string Description, string Name, int Quantity);