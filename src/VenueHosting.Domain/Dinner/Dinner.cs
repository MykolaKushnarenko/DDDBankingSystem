using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Dinner.Entities;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Host.ValueObjects;
using VenueHosting.Domain.Menu.ValueObjects;

namespace VenueHosting.Domain.Dinner;

public sealed class Dinner : AggregateRote<DinnerId>
{
    private readonly List<Reservation> _reservationIds = new();

    private Dinner(DinnerId id, string name, string description, DateTime startDateTime, DateTime endDateTime,
        DateTime? startedDateTime, DateTime? endedDateTime, bool isPublic, int maxGuests, Price price, HostId hostId,
        MenuId menuId, string imageUrl, Location location, DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public DateTime StartDateTime { get; private set; }

    public DateTime EndDateTime { get; private set; }
    
    public DateTime? StartedDateTime { get; private set; }

    public DateTime? EndedDateTime { get; private set; }

    public bool IsPublic { get; private set; }
    
    public int MaxGuests { get; private set; }
    
    public Price Price { get; private set; }
    
    public HostId HostId { get; private set; }
    
    public MenuId MenuId { get; private set; }
    
    public string ImageUrl { get; private set; }
    
    public Location Location { get; private set; }

    public IReadOnlyList<Reservation> ReservationIds => _reservationIds.AsReadOnly();
    
    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Dinner Create(
        string name, 
        string description, 
        DateTime startDateTime, 
        DateTime endDateTime,
        DateTime? startedDateTime, 
        DateTime? endedDateTime,
        bool isPublic, 
        int maxGuests, 
        Price price, 
        HostId hostId,
        MenuId menuId, 
        string imageUrl, 
        Location location)
    {
        return new Dinner(DinnerId.CreateUnique(), name, description, startDateTime, endDateTime, startedDateTime,
            endedDateTime, isPublic, maxGuests, price, hostId, menuId, imageUrl, location, DateTime.UtcNow,
            DateTime.UtcNow);
    }
}