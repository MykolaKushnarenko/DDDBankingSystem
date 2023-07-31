using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

public class AddActivitiesCommand : IRequest<Unit>
{
    public VenueId VenueId { get; init; }
    public IList<ActivityCommand> Activities { get; init; }
}