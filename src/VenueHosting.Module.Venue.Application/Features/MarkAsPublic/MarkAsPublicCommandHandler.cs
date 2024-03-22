using Component.Domain.Persistence.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Application.Extensions;
using VenueHosting.Module.Venue.Domain.Repositories;
using VenueHosting.Module.Venue.Domain.Services;

namespace VenueHosting.Module.Venue.Application.Features.MarkAsPublic;

internal sealed class MarkAsPublicCommandHandler : IRequestHandler<MarkAsPublicCommand, Unit>
{
    private readonly IVenueRepository _venueRepository;
    private readonly IAtomicScope _atomicScope;
    private readonly VenueDomainService _venueDomainService;

    public MarkAsPublicCommandHandler(IVenueRepository venueRepository, VenueDomainService venueDomainService,
        IAtomicScope atomicScope)
    {
        _venueRepository = venueRepository;
        _venueDomainService = venueDomainService;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(MarkAsPublicCommand request, CancellationToken cancellationToken)
    {
        var venue = await _venueRepository.FindOneOrThrowAsync(request.VenueId, cancellationToken);

        _venueDomainService.MarkAsPublic(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}