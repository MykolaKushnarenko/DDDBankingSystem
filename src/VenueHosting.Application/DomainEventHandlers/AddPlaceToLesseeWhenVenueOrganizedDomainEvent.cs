using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Application.Common.Specifications;
using VenueHosting.Domain.Lessee;
using VenueHosting.Domain.Venue.DomainEvents;

namespace VenueHosting.Application.DomainEventHandlers;

internal sealed class AddPlaceToLesseeWhenVenueOrganizedDomainEvent : INotificationHandler<VenueOrganizedDomainEvent>
{
    private readonly ILesseeStore _lesseeStore;

    public AddPlaceToLesseeWhenVenueOrganizedDomainEvent(ILesseeStore lesseeStore)
    {
        _lesseeStore = lesseeStore;
    }

    public async Task Handle(VenueOrganizedDomainEvent notification, CancellationToken cancellationToken)
    {
        Lessee? lessee = await _lesseeStore.FetchBySpecification(new FindLesseeByIdSpecification(notification.LesseeId),
            cancellationToken);

        lessee.AddRegistredVenue(notification.VenueId);
    }
}