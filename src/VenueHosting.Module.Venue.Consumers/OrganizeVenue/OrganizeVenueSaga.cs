using MassTransit;
using VenueHosting.Contracts.Events;

namespace VenueHosting.Module.Venue.Consumers.OrganizeVenue;

public class OrganizeVenueSaga :
    MassTransitStateMachine<VenueState>
{
    public State Initiated { get; private set; }
    public State Booked { get; private set; }
    public State Paid { get; private set; }

    public OrganizeVenueSaga()
    {
        InstanceState(x => x.CurrentState);

        Event(() => CreateVenue,
            x => x.CorrelateById(context => context.Message.VenueId));
        Event(() => VenueBooked,
            x => x.CorrelateById(context => context.Message.VenueId));
        Event(() => VenuePaid,
            x => x.CorrelateById(context => context.Message.VenueId));

        Initially(
            When(CreateVenue)
                .SendAsync<VenueState, VenueCreatedIntegrationEvent, BookVenueCommand>(new Uri("queue:book.venue"),
                    context => Task.FromResult(new BookVenueCommand(context.Message.VenueId)))
                .TransitionTo(Initiated));

        During(
            Initiated,
            When(VenueBooked)
                .TransitionTo(Booked));


        SetCompletedWhenFinalized();
    }

    public Event<VenueCreatedIntegrationEvent> CreateVenue { get; private set; }
    public Event<VenueBooked> VenueBooked { get; private set; }
    public Event<VenuePayed> VenuePaid { get; private set; }
}

public class VenueState :
    SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public int CurrentState { get; set; }
    public DateTime Time { get; set; }
    public string OwnerId { get; set; }
    public Guid VenueId { get; set; }
}

public record InitiateVenue(Guid VenueId);

public record BookVenueCommand(Guid VenueId);

public class VenueBooked
{
    public Guid VenueId { get; set; }
}

public class MakePaymentForVenue
{
    public Guid VenueId { get; set; }
}

public class VenuePayed
{
    public Guid VenueId { get; set; }
}