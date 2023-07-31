namespace VenueHosting.Module.Venue.Api.Requests;

public class AddReviewRequest
{
    public string VenueId { get; init; }

    public string AuthorId { get; init; }

    public string Comment { get; init; }

    public float RatingGiven { get; init; }
}