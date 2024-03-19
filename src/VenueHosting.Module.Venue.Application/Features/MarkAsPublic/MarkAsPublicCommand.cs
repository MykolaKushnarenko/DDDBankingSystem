using Component.Domain.Models;
using MediatR;

namespace VenueHosting.Module.Venue.Application.Features.MarkAsPublic;

public class MarkAsPublicCommand : IRequest<Unit>
{
    public MarkAsPublicCommand(Guid venueId)
    {
        VenueId = new Id<Domain.Aggregates.VenueAggregate.Venue>(venueId);
    }

    public Id<Domain.Aggregates.VenueAggregate.Venue> VenueId { get; init; }
}