using MediatR;
using VenueHosting.Module.Venue.Domain.Venue.ValueObjects;

namespace VenueHosting.Module.Venue.Application.Features.ChangeVisibility;

public class ChangeVisibilityCommand : IRequest<Unit>
{
    public VenueId VenueId { get; init; }

    public Visibility Visibility { get; init; }
}