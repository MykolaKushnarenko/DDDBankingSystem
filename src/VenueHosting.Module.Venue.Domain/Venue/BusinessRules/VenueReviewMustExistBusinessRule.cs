using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Venue.Entities;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Venue.BusinessRules;

internal sealed class VenueReviewMustExistBusinessRule : IBusinessRule
{
    private readonly IList<VenueReview> _allReviews;

    private readonly VenueReview _reviewToRemove;

    public VenueReviewMustExistBusinessRule(IList<VenueReview> allReviews,
        VenueReview reviewToRemove)
    {
        _allReviews = allReviews;
        _reviewToRemove = reviewToRemove;
    }

    public void CheckIfSatisfied()
    {
        if (!_allReviews.Contains(_reviewToRemove))
        {
            throw new VenueReviewNotFoundException();
        }
    }
}