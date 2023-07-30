using MediatR;
using VenueHosting.Module.Venue.Application.Common.Persistence;
using VenueHosting.Module.Venue.Domain.Exceptions;
using VenueHosting.Module.Venue.Domain.Venue.Entities;

namespace VenueHosting.Module.Venue.Application.Features.ReserveAttendance;

internal sealed class ReserveAttendanceCommandHandler : IRequestHandler<ReserveAttendanceCommand, Unit>
{
    private readonly IVenueStore _venueStore;
    private readonly IAtomicScope _atomicScope;

    public ReserveAttendanceCommandHandler(IVenueStore venueStore, IAtomicScope atomicScope)
    {
        _venueStore = venueStore;
        _atomicScope = atomicScope;
    }

    public async Task<Unit> Handle(ReserveAttendanceCommand request, CancellationToken cancellationToken)
    {
        Domain.Venue.Venue? venue = await _venueStore.FetchVenueByIdAsync(request.VenueId, cancellationToken);

        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        Reservation reservation = Reservation.Create(request.AttendeeId, request.BillId, request.Amount,
            request.ReservationDateTime);

        venue.Reserve(reservation);

        await _atomicScope.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}