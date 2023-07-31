using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Module.Venue.Api.Requests;
using VenueHosting.Module.Venue.Application.Features.AddReview;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
using VenueHosting.SharedKernel.Controllers;

namespace VenueHosting.Module.Venue.Api.Controllers;

/// <summary>
/// Review controller
/// </summary>
[Route("venues")]
[AllowAnonymous]
public class ReviewController : ApiController
{
    private readonly ISender _sender;

    public ReviewController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Add review to the event
    /// </summary>
    /// <remarks>
    /// Request example:
    /// <code>
    /// POST <![CDATA[/venues/{venueId}/reviews]]>
    /// {
    ///
    /// }
    /// </code>
    /// </remarks>
    /// <returns></returns>
    [HttpPost("{venueId}/reviews")]
    public async Task<IActionResult> AddActivitiesAsync(string venueId, [FromBody] AddReviewRequest request)
    {
        AddReviewCommand command = new()
        {
            VenueId = VenueId.Create(Guid.Parse(venueId)),
            AuthorId = AttendeeId.Create(Guid.Parse(request.AuthorId)),
            Comment = request.Comment,
            RatingGiven = request.RatingGiven,

        };

        await _sender.Send(command);

        return Ok();
    }
}