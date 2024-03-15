using Component.Domain.Models;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Venue.Entities;

public class PartnerReference : Entity<PartnerReference>
{
    private PartnerReference()
    {
    }

    public PartnerReference(Id<Partner.Partner> partnerId, Id<PartnerReference>? id) : base(
        id ?? Id<PartnerReference>.CreateUnique())
    {
        PartnerId = partnerId;
    }

    public Id<Partner.Partner> PartnerId { get; private set; }
}