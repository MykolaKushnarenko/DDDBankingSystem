using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Place.Application.Features.Place.GetPlace;
using VenueHosting.Module.Place.Application.Features.Place.RegisterNewPlace;
using VenueHosting.Module.Place.Domain.Owner.ValueObjects;
using VenueHosting.SharedKernel.Controllers;

namespace VenueHosting.Module.Place.Api;

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

        Domain.Place.Place place = await _sender.Send(command);

        return Ok(place);
    }

    [HttpGet("{placeId}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid placeId)
    {
        GetPlaceQuery command = new GetPlaceQuery(placeId);

        Domain.Place.Place place = await _sender.Send(command);

        return Ok(place);
    }


    public record RegisterNewPlaceRequest(string OwnerId, AddressRequest AddressCommand,
        List<FacilityRequest> FacilityCommand);

    public record GetPlaceRequest(string OwnerId);

    public record AddressRequest(string Country, string City, string Street, int Number);

    public record FacilityRequest(string Description, string Name, int Quantity);
}