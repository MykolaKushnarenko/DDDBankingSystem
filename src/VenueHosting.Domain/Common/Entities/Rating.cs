using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Host.ValueObjects;

namespace VenueHosting.Domain.Common.Entities;

public sealed class Rating : Entity<RatingId>
{
    private Rating(RatingId id, HostId hostId, DinnerId dinnerId, int value, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Value = value;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public HostId HostId { get; private set; }
    
    public DinnerId DinnerId { get; private set; }
    
    public int Value { get; private set; }
    
    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Rating Create(HostId hostId, DinnerId dinnerId, int value)
    {
        return new Rating(RatingId.CreateUnique(), hostId, dinnerId, value, DateTime.UtcNow, DateTime.UtcNow);
    }
}