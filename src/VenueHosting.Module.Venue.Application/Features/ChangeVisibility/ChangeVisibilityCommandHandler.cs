using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Application.Features.ChangeVisibility;

internal sealed class ChangeVisibilityCommandHandler : IRequestHandler<ChangeVisibilityCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;

    public ChangeVisibilityCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(ChangeVisibilityCommand request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        venue.ChangeVisibility(request.Visibility);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}