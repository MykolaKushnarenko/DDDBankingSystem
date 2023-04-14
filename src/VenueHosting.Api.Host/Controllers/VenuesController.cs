using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Features.Venue.FindVenuesByLocation;
using VenueHosting.Application.Features.Venue.OrganizeVenue;
using VenueHosting.Domain.Lessee.ValueObjects;
using VenueHosting.Domain.Owner.ValueObjects;
using VenueHosting.Domain.Place.ValueObjects;
using VenueHosting.Domain.Venue;

namespace VenueHosting.Api.Host.Controllers;

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
        IReadOnlyList<Venue> venue = await _sender.Send(request);

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