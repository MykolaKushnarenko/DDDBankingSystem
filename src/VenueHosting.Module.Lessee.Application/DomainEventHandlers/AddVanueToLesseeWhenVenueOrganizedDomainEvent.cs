// using MediatR;
// using VenueHosting.Module.Lessee.Application.Common.Persistence;
// using VenueHosting.Module.Lessee.Application.Common.Specifications;
// using VenueHosting.Module.Lessee.Domain.Lessee.ValueObjects;
//
// namespace VenueHosting.Module.Lessee.Application.DomainEventHandlers;
//
// internal sealed class AddVanueToLesseeWhenVenueOrganizedDomainEvent : INotificationHandler<VenueOrganizedDomainEvent>
// {
//     private readonly ILesseeStore _lesseeStore;
//
//     public AddVanueToLesseeWhenVenueOrganizedDomainEvent(ILesseeStore lesseeStore)
//     {
//         _lesseeStore = lesseeStore;
//     }
//
//     public async Task Handle(VenueOrganizedDomainEvent notification, CancellationToken cancellationToken)
//     {
//         Domain.Lessee.Lessee? lessee = await _lesseeStore.FetchBySpecification(new FindLesseeByIdSpecification(LesseeId.Create(notification.LesseeId)),
//             cancellationToken);
//
//         lessee.AddRegisteredVenue(VenueId.Create(notification.VenueId));
//     }
// }