using VenueHosting.Domain.Common.Models;
using VenueHosting.Domain.Menu.ValueObjects;

namespace VenueHosting.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    private MenuItem(MenuItemId id, string name, string description) : base(id)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    private MenuItem()
    {
    }

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}