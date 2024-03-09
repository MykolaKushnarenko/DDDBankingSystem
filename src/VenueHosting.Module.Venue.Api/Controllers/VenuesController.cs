using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Venue.Api.Requests;
using VenueHosting.Module.Venue.Application.Features.AddActivities;
using VenueHosting.Module.Venue.Application.Features.CancelReservation;
using VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;
using VenueHosting.Module.Venue.Application.Features.MarkAsPublic;
using VenueHosting.Module.Venue.Application.Features.OrganizeVenue;
using VenueHosting.Module.Venue.Application.Features.ReserveAttendance;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.Module.Venue.Domain.Replicas.Place.ValueObjects;
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

        var venue = await _sender.Send(command);
        //Map into response

        return Ok(venue);
    }

    /// <summary>
    /// Add activity(ies) to the event
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
    [HttpPost("{venueId}/activities")]
    public async Task<IActionResult> AddActivitiesAsync(string venueId, [FromBody] ActivitiesRequest request)
    {
        AddActivitiesCommand command = new()
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            Activities = request.Activity.ConvertAll(x => new ActivityCommand
            {
                Name = x.Name,
                Description = x.Description
            }).ToArray()
        };

        await _sender.Send(command);

        return Ok();
    }

    /// <summary>
    /// Change status of the event
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// PUT <![CDATA[/venues]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpPut("{venueId}/visibility")]
    public async Task<IActionResult> ChangeVisibilityAsync(string venueId, [FromBody] ChangeVisibilityRequest request)
    {
        var command = new MarkAsPublicCommand
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            Visibility = request.Visibility
        };

        await _sender.Send(command);

        return Ok();
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
    [HttpPost("{venueId}/reservation")]
    public async Task<IActionResult> ReserveAsync(string venueId, [FromBody] ReserveRequest request)
    {
        ReserveAttendanceCommand reserveCommand = new()
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            UserId = UserId.Create(Guid.Parse(request.AttendeeId!)),
            BillId = BillId.Create(Guid.Parse(request.BillId!)),
            Amount = request.Amount,
            ReservationDateTime = request.ReservationDateTime
        };

        await _sender.Send(reserveCommand);

        return Ok();
    }

    /// <summary>
    /// Cancel reservation
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// POST <![CDATA[/venues/{venueId}/reservation/{reservationId}/cancel]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpPost("{venueId}/reservation/{reservationId}/cancel")]
    public async Task<IActionResult> CancelReservationAsync(string venueId, string reservationId)
    {
        CancelReservationCommand command = new()
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            ReservationId = ReservationId.Create(Guid.Parse(reservationId)),
        };

        await _sender.Send(command);

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
        var venue = await _sender.Send(request);

        return Ok(venue);
    }
}