// using MediatR;
// using VenueHosting.Domain.Place.DomainEvents;
// using VenueHosting.Module.Venue.Application.Common.Persistence;
// using VenueHosting.Module.Venue.Application.Common.Specifications;
// using VenueHosting.Module.Venue.Domain.Place.ValueObjects;
// using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;
//
// namespace VenueHosting.Module.Venue.Application.DomainEventHandlers;
//
// internal sealed class ChangeVenueStatusWhenPlacePaidAndBooked : INotificationHandler<PlaceSuccessfullyBooked>
// {
//     private readonly IVenueStore _venueStore;
//     private readonly IAtomicScope _atomicScope;
//
//     public ChangeVenueStatusWhenPlacePaidAndBooked(
//         IVenueStore venueStore,
//         IAtomicScope atomicScope)
//     {
//         _venueStore = venueStore;
//         _atomicScope = atomicScope;
//     }
//
//     public async Task Handle(PlaceSuccessfullyBooked notification, CancellationToken cancellationToken)
//     {
//         FindVenuesByPlaceIdAndStatusSpecification specification =
//             new FindVenuesByPlaceIdAndStatusSpecification(PlaceId.Create(notification.PlaceId), VenueStatus.InPayment);
//         Domain.Venue.Venue? venue = await _venueStore.FetchBySpecification(specification, cancellationToken);
//
//         ArgumentNullException.ThrowIfNull(venue);
//
//         venue.ChangeStatus(VenueStatus.Organized);
//
//         await _atomicScope.CommitAsync(cancellationToken);
//     }
// }