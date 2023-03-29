using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Common.ValueObjects;
using VenueHosting.Domain.Dinner.ValueObjects;
using VenueHosting.Domain.Host.ValueObjects;
using VenueHosting.Domain.Menu.Entities;
using VenueHosting.Domain.Menu.ValueObjects;
using VenueHosting.Domain.MenuReview.ValueObjects;

namespace VenueHosting.Domain.Menu;

public sealed class Menu : AggregateRote<MenuId>
{
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuSection> _menuSections = new();
    
    private Menu(MenuId id, string name, string description, HostId hostId,
        DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public AverageRating AverageRating { get; private set; }
    
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.AsReadOnly();
    
    public HostId HostId { get; private set; }
    
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    
    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddDinner(Dinner.Dinner dinner)
    {
        _dinnerIds.Add(dinner.Id);
    }

    public void RemoveDinner(Dinner.Dinner dinner)
    {
        _dinnerIds.Remove(dinner.Id);
    }

    public void UpdateSection(MenuSection section)
    {
        _menuSections.Add(section);
    }
}