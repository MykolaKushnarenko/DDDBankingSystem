using MediatR;
using VenueHosting.SharedKernel.Domain;

namespace VenueHosting.Module.Venue.Application.Features.MarkAsPublic;

public class MarkAsPublicCommand : IRequest<Unit>
{
    public Id<Domain.Aggregates.Venue.Venue> VenueId { get; init; }
}