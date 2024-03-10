using Component.Domain.Models;
using VenueHosting.Module.Venue.Domain.Replicas.User;

namespace VenueHosting.Module.Venue.Domain.Aggregates.Partner;

public class Partner : AggregateRote<Partner>
{
    private Partner()
    {
    }

    internal Partner(Id<User> representativeId, string companyName)
    {
        RepresentativeId = representativeId;
        CompanyName = companyName;
    }

    public Id<User> RepresentativeId { get; set; }
    public string CompanyName { get; set; }
}