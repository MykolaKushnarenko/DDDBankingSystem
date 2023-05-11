using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Venue.DomainEvents;

namespace VenueHosting.Application.DomainEventHandlers;

internal sealed class
    ReservePlaceWhenVenueOrganizedDomainEventHandler : INotificationHandler<VenueOrganizedDomainEvent>
{
    private readonly IPlaceStore _placeStore;

    public ReservePlaceWhenVenueOrganizedDomainEventHandler(IPlaceStore placeStore)
    {
        _placeStore = placeStore;
    }

    public async Task Handle(VenueOrganizedDomainEvent notification, CancellationToken cancellationToken)
    {
        Domain.Place.Place? place = await _placeStore.FetchBySpecification(
            new FindPlaceByPlaceIdSpecification(notification.PlaceId),
            cancellationToken);

        ArgumentNullException.ThrowIfNull(place);

        place.ReservePlace();
    }
}