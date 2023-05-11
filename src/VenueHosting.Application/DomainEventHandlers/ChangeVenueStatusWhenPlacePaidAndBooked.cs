using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Persistence.AtomicScope;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Place.DomainEvents;
using VenueHosting.Domain.Venue;
using VenueHosting.Domain.Venue.ValueObjects;

namespace VenueHosting.Application.DomainEventHandlers;

internal sealed class ChangeVenueStatusWhenPlacePaidAndBooked : INotificationHandler<PlaceSuccessfullyBooked>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;

    public ChangeVenueStatusWhenPlacePaidAndBooked(IVenueStore venueStore, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
    }

    public async Task Handle(PlaceSuccessfullyBooked notification, CancellationToken cancellationToken)
    {
        FindVenuesByPlaceIdAndStatusSpecification specification =
            new FindVenuesByPlaceIdAndStatusSpecification(notification.PlaceId, VenueStatus.InPayment);
        Venue? venue = await _venueStore.FetchBySpecification(specification, cancellationToken);

        ArgumentNullException.ThrowIfNull(venue);

        venue.Organize();

        await _atomicScope.CommitAsync(cancellationToken);
    }
}