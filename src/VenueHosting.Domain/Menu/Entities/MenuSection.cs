using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Menu.ValueObjects;

namespace VenueHosting.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection()
    {
    }

    private MenuSection(MenuSectionId id, string name, string description, List<MenuItem> items) : base(id)
    {
        Name = name;
        Description = description;
        _items = items;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description, items);
    }
}