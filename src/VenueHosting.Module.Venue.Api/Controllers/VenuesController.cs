using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Venue.Api.Requests;
using VenueHosting.Module.Venue.Application.Features.AddActivities;
using VenueHosting.Module.Venue.Application.Features.FindVenuesByLocation;
using VenueHosting.Module.Venue.Application.Features.MarkAsPublic;
using VenueHosting.Module.Venue.Application.Features.OrganizeVenue;
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
            request.HostId,
            request.PlaceId,
            request.EventName,
            request.Description,
            request.Capacity,
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
    public async Task<IActionResult> AddActivitiesAsync(Guid venueId, [FromBody] ActivitiesRequest request)
    {
        AddActivitiesCommand command = new(venueId, request.Activity.ConvertAll(x => new ActivityCommand
        {
            Name = x.Name,
            Description = x.Description
        }).ToArray());

        await _sender.Send(command);

        return Ok();
    }

    /// <summary>
    /// Change status of the event
    /// </summary>
    /// <returns></returns>
    [HttpPut("{venueId}/visibility")]
    public async Task<IActionResult> ChangeVisibilityAsync(Guid venueId)
    {
        var command = new MarkAsPublicCommand(venueId);

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