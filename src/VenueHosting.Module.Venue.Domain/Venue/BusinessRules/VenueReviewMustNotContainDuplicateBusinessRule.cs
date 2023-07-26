using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Venue.Entities;
using VenueHosting.SharedKernel.BLSpecifications;

namespace VenueHosting.Module.Venue.Domain.Venue.BusinessRules;

internal sealed class VenueReviewMustNotContainDuplicateBusinessRule : IBusinessRule
{
    private readonly IList<VenueReview> _allReviews;

    private readonly VenueReview _addingReview;

    public VenueReviewMustNotContainDuplicateBusinessRule(IList<VenueReview> allReviews,
        VenueReview addingReview)
    {
        _allReviews = allReviews;
        _addingReview = addingReview;
    }

    public void CheckIfSatisfied()
    {
        if (_allReviews.Contains(_addingReview))
        {
            throw new VenueReviewDuplicateFoundException();
        }
    }
}