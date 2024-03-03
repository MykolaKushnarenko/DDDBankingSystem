using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Common.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;


public sealed class VenueReview : Entity<VenueReviewId>
{
    private VenueReview()
    {
    }

    private VenueReview(VenueReviewId id, UserId authorId, string comment, float ratingGiven,
        DateTime createdDateTime) : base(id)
    {
        AuthorId = authorId;
        Comment = comment;
        RatingGiven = ratingGiven;
        CreatedDateTime = createdDateTime;
    }

    public UserId AuthorId { get; private set; }

    public string Comment { get; private set; }

    public float RatingGiven { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public static VenueReview Create(UserId authorId, string comment, float ratingGiven, DateTime createdDateTime)
    {
        return new VenueReview(VenueReviewId.CreateUnique(), authorId, comment, ratingGiven,
            createdDateTime);
    }
}