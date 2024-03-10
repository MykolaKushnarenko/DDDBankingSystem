using Component.Persistence.SqlServer.AtomicScope;
using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Services;

namespace VenueHosting.Module.Venue.Application.Features.MarkAsPublic;

internal sealed class MarkAsPublicCommandHandler : IRequestHandler<MarkAsPublicCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;
    private readonly VenueDomainService _venueDomainService;

    public MarkAsPublicCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope, VenueDomainService venueDomainService)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
        _venueDomainService = venueDomainService;
    }

    public async Task<Unit> Handle(MarkAsPublicCommand request, CancellationToken cancellationToken)
    {
        var venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        _venueDomainService.MarkAsPublic(venue);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}