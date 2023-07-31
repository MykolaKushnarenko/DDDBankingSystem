using MediatR;
using VenueHosting.Application.Common.Interfaces;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Venue.Entities;

namespace VenueHosting.Module.Venue.Application.Features.AddReview;

internal sealed class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddReviewCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope, IDateTimeProvider dateTimeProvider)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Unit> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        VenueReview review = VenueReview.Create(request.AuthorId, request.Comment, request.RatingGiven,
            _dateTimeProvider.GetUtcNow());

        venue.AddReview(review);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}