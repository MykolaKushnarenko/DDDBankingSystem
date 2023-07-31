using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;

namespace VenueHosting.Module.Venue.Application.Features.CancelReservation;

internal sealed class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;

    public CancelReservationCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
    }

    public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        venue.CancelReservation(request.ReservationId);

        await _atomicScope.CommitAsync(cancellationToken);
    }
}