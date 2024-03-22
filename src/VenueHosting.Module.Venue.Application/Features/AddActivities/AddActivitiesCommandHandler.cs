using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Application.Extensions;
using VenueHosting.Module.Venue.Domain.Repositories;
using VenueHosting.Module.Venue.Domain.Services;

namespace VenueHosting.Module.Venue.Application.Features.AddActivities;

internal sealed class AddActivitiesCommandHandler : IRequestHandler<AddActivitiesCommand, Unit>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IAtomicScope _atomicScope;
    private readonly VenueDomainService _venueDomainService;

    public AddActivitiesCommandHandler(IVenueRepository venueRepository,
        VenueDomainService venueDomainService, IAtomicScope atomicScope)
    {
        _venueRepository = venueRepository;
        _venueDomainService = venueDomainService;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(AddActivitiesCommand request, CancellationToken cancellationToken)
    {
        var venue = await _venueRepository.FindOneOrThrowAsync(request.VenueId, cancellationToken);

        foreach (var activityCommand in request.Activities)
        {
            var activity = _venueDomainService.CreateActivity(activityCommand.Name, activityCommand.Description);
            _venueDomainService.AddActivity(venue, activity);
        }

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}