using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.CancelReservation;

public sealed class CancelReservationCommand : IRequest
{
    public VenueId VenueId { get; init; }

    public ReservationId ReservationId { get; init; }
}