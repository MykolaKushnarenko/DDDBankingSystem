using Component.Domain.Models;
using VenueHosting.Module.Venue.Domain.Aggregates.PartnerAggregate;

namespace VenueHosting.Module.Venue.Domain.Aggregates.VenueAggregate.Entities;

public class PartnerReference : Entity<PartnerReference>
{
    private PartnerReference()
    {
    }

    public PartnerReference(Id<Partner> partnerId, Id<PartnerReference>? id) : base(
        id ?? Id<PartnerReference>.CreateUnique())
    {
        PartnerId = partnerId;
    }

    public Id<Partner> PartnerId { get; private set; }
}