using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Services;
using VenueHosting.Module.Venue.Domain.Specifications.VenueAggregate;
using VenueHosting.Module.Venue.Domain.Stores;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

internal sealed class AddActivitiesCommandHandler : IRequestHandler<AddActivitiesCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;
    private readonly VenueDomainService _venueDomainService;

    public AddActivitiesCommandHandler(IVenueStore venueStore,
        VenueDomainService venueDomainService, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _venueDomainService = venueDomainService;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(AddActivitiesCommand request, CancellationToken cancellationToken)
    {
        var venue = await _venueStore.FindOneAsync(VenueByVenueIdSpec.Create(request.VenueId), cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        foreach (var activityCommand in request.Activities)
        {
            var activity = _venueDomainService.CreateActivity(activityCommand.Name, activityCommand.Description);
            _venueDomainService.AddActivity(venue, activity);
        }

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}