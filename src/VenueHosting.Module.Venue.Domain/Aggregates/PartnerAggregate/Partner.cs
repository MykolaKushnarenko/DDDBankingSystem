using Component.Domain.Models;
using JetBrains.Annotations;
using VenueHosting.Module.Venue.Domain.Replicas.UserAggregate;

namespace VenueHosting.Module.Venue.Domain.Aggregates.PartnerAggregate;

public class Partner : AggregateRote<Partner>
{
    [UsedImplicitly]
    private Partner()
    {
    }

    internal Partner(Id<User> representativeId, string companyName)
    {
        RepresentativeId = representativeId;
        CompanyName = companyName;
    }

    public Id<User> RepresentativeId { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
}