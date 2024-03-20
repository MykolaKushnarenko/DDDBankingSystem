using Ardalis.Specification;
using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Specifications.VenueAggregate;

public sealed class VenueByVenueIdSpec : Specification<Aggregates.VenueAggregate.Venue>
{
    public VenueByVenueIdSpec(Id<Aggregates.VenueAggregate.Venue> id)
    {
        Query.Where(x => x.Id == id);
    }

    public static VenueByVenueIdSpec Create(Id<Aggregates.VenueAggregate.Venue> id)
    {
        return new VenueByVenueIdSpec(id);
    }
}