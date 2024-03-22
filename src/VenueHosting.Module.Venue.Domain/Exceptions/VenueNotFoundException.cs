using Component.Domain.Exceptions;
using Component.Domain.Models;
using Components.Validation.Exceptions;

namespace VenueHosting.Module.Venue.Domain.Exceptions;

public sealed class VenueNotFoundException : DomainException
{
    public VenueNotFoundException(Id<Aggregates.VenueAggregate.Venue> id) : base(
        $"Venue with id: {id.Value} was not found.")
    {
    }

    public override int ErrorCode => 1000;
    public override ErrorType ErrorType => ErrorType.ResourceNotFound;
}