using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.AddReview;

public class AddReviewCommand : IRequest<Unit>
{
    public VenueId VenueId { get; init; }

    public AttendeeId AuthorId { get; init; }

    public string Comment { get; init; }

    public float RatingGiven { get; init; }
}