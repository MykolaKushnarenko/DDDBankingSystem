using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.ReserveAttendance;

public class ReserveAttendanceCommand : IRequest<Unit>
{
    public VenueId VenueId { get; init; }

    public AttendeeId AttendeeId { get; init; }

    public BillId BillId { get; init; }

    public int Amount { get; init; }

    public DateTime ReservationDateTime { get; init; }
}