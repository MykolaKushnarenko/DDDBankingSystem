using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Menu.ValueObjects;

namespace VenueHosting.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _item = new();
    
    private MenuSection(MenuSectionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }
    
    public IReadOnlyList<MenuItem> Items => _item.AsReadOnly();

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}