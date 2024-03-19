using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Services;

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
        var venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        foreach (var activityCommand in request.Activities)
        {
            _venueDomainService.AddActivity(venue, activityCommand.Name, activityCommand.Description);
        }

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}