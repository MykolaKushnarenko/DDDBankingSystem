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
    private readonly List<MenuSection> _sections = new();

    private Menu()
    {
    }

    private Menu(MenuId id, string name, string description, HostId hostId,
        List<MenuSection> sections,
        DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Menu Create(HostId hostId, string name, string description, List<MenuSection> sections)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId, sections, DateTime.UtcNow,
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
        _sections.Add(section);
    }
}