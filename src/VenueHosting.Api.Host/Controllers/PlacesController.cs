using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Features.Place.RegisterNewPlace;
using VenueHosting.Application.Features.Venue.OrganizeVenue;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place;
using VenueHosting.Domain.Place.ValueObjects;

namespace VenueHosting.Api.Host.Controllers;

[Route("place")]
[AllowAnonymous]
public class PlacesController : ApiController
{
    private readonly ISender _sender;

    public PlacesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]RegisterNewPlaceRequest request)
    {
        AddressCommand addressCommand = new AddressCommand(request.AddressCommand.Country, request.AddressCommand.City,
            request.AddressCommand.Street, request.AddressCommand.Number);

        List<FacilityCommand> facility = request.FacilityCommand
            .Select(x => new FacilityCommand(x.Description, x.Name, x.Quantity)).ToList();

        RegisterNewPlaceCommand command = new RegisterNewPlaceCommand(OwnerId.Create(Guid.Parse(request.OwnerId)), addressCommand, facility);

        Place place = await _sender.Send(command);

        return Ok(place);
    }


    public record RegisterNewPlaceRequest(string OwnerId, AddressRequest AddressCommand,
        List<FacilityRequest> FacilityCommand);

    public record AddressRequest(string Country, string City, string Street, int Number);

    public record FacilityRequest(string Description, string Name, int Quantity);
}