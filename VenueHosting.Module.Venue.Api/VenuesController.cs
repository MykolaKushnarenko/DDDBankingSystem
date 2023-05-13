using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;
using VenueHosting.Module.Venue.Application.Features.OrganizeVenue;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Controllers;

namespace VenueHosting.Module.Venue.Api;

[Route("venues")]
[AllowAnonymous]
public class VenuesController : ApiController
{
    private readonly ISender _sender;

    public VenuesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody]OrganizeVenueRequest request)
    {
        OrganizeVenueCommand command = new OrganizeVenueCommand(OwnerId.Create(Guid.Parse(request.ownerId)),
            LesseeId.Create(Guid.Parse(request.lesseeId)),
            PlaceId.Create(Guid.Parse(request.placeId)),
            request.eventName,
            request.description,
            request.isPublic,
            request.startAtDateTime,
            request.endAtDateTime);

        var venue = await _sender.Send(command);

        return Ok(venue);
    }

    [HttpGet]
    public async Task<IActionResult> FindClosestVenues([FromQuery]FindVenuesByLocationQuery request)
    {
        IReadOnlyList<VenueHosting.Module.Venue.Domain.Venue.Venue> venue = await _sender.Send(request);

        return Ok(venue);
    }


    public record OrganizeVenueRequest(string ownerId,
        string lesseeId,
        string placeId,
        string eventName,
        string description,
        bool isPublic,
        DateTime startAtDateTime,
        DateTime endAtDateTime);
}