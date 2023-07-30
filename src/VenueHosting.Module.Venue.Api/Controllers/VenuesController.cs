using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Venue.Api.Requests;
using VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;
using VenueHosting.Module.Venue.Application.Features.OrganizeVenue;
using VenueHosting.Module.Venue.Application.Features.ReserveAttendance;
using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Controllers;

namespace VenueHosting.Module.Venue.Api.Controllers;

/// <summary>
/// Venue controller
/// </summary>
[Route("venues")]
[AllowAnonymous]
public class VenuesController : ApiController
{
    private readonly ISender _sender;

    public VenuesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Organize event
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// POST <![CDATA[/venues]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> OrganizeAsync([FromBody] OrganizeVenueRequest request)
    {
        OrganizeVenueCommand command = new OrganizeVenueCommand(
            OwnerId.Create(Guid.Parse(request.OwnerId)),
            LesseeId.Create(Guid.Parse(request.LesseeId)),
            PlaceId.Create(Guid.Parse(request.PlaceId)),
            request.EventName,
            request.Description,
            request.Visibility,
            request.StartAtDateTime,
            request.EndAtDateTime);

        Domain.Venue.Venue venue = await _sender.Send(command);
        //Map into response

        return Ok(venue);
    }

    /// <summary>
    /// Reserve event
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// POST <![CDATA[/venues/{venueId}/reserve]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpPost("{venueId}/reserve")]
    public async Task<IActionResult> ReserveAsync(string venueId, [FromBody] ReserveRequest request)
    {
        ReserveAttendanceCommand reserveCommand = new()
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            AttendeeId = AttendeeId.Create(Guid.Parse(request.AttendeeId!)),
            BillId = BillId.Create(Guid.Parse(request.BillId!)),
            Amount = request.Amount,
            ReservationDateTime = request.ReservationDateTime
        };

        await _sender.Send(reserveCommand);

        return Ok();
    }

    /// <summary>
    /// Get the closest event
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// POST <![CDATA[/venues]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpGet("/nearest")]
    public async Task<IActionResult> FindClosestVenues([FromQuery]FindVenuesByLocationQuery request)
    {
        IReadOnlyList<Domain.Venue.Venue> venue = await _sender.Send(request);

        return Ok(venue);
    }
}