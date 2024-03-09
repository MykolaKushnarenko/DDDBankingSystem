using VenueHosting.Module.Venue.Domain.Replicas.User;
using VenueHosting.SharedKernel.Common.Models;
using VenueHosting.SharedKernel.Domain;

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