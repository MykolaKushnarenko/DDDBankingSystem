// using MediatR;
// using VenueHosting.Module.Place.Application.Common.Persistence;
// using VenueHosting.Module.Place.Application.Common.Specifications;
//
// namespace VenueHosting.Module.Place.Application.DomainEventHandlers;
//
// internal sealed class
//     ReservePlaceWhenVenueOrganizedDomainEventHandler : INotificationHandler<VenueOrganizedDomainEvent>
// {
//     private readonly IPlaceStore _placeStore;
//
//     public ReservePlaceWhenVenueOrganizedDomainEventHandler(IPlaceStore placeStore)
//     {
//         _placeStore = placeStore;
//     }
//
//     public async Task Handle(VenueOrganizedDomainEvent notification, CancellationToken cancellationToken)
//     {
//         VenueHosting.Module.User.Domain.Place.Place? place = await _placeStore.FetchBySpecification(
//             new FindPlaceByPlaceIdSpecification(notification.PlaceId),
//             cancellationToken);
//
//         ArgumentNullException.ThrowIfNull(place);
//
//         place.ReservePlace();
//     }
// }