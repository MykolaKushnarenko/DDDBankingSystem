using Component.Domain.Models;
using MediatR;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

public class AddActivitiesCommand : IRequest<Unit>
{
    public AddActivitiesCommand(Guid venueId, IList<ActivityCommand> activities)
    {
        Activities = activities;
        VenueId = new Id<Domain.Aggregates.VenueAggregate.Venue>(venueId);
    }

    public Id<Domain.Aggregates.VenueAggregate.Venue> VenueId { get; init; }
    public IList<ActivityCommand> Activities { get; init; }
}