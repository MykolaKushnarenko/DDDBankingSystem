using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

internal sealed class AddActivitiesCommandHandler : IRequestHandler<AddActivitiesCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;

    public AddActivitiesCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(AddActivitiesCommand request, CancellationToken cancellationToken)
    {
        Domain.Aggregates.Venue.Venue? venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        foreach (ActivityCommand activityCommand in request.Activities)
        {
            Activity activity = Activity.Create(activityCommand.Name, activityCommand.Description);

            venue.AddActivity(activity);
        }

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}