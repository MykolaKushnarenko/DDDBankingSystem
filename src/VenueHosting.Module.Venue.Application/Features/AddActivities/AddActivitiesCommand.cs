using MediatR;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.ValueObjects;
using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

public class AddActivitiesCommand : IRequest<Unit>
{
    public Id<Domain.Aggregates.Venue.Venue> VenueId { get; init; }
    public IList<ActivityCommand> Activities { get; init; }
}