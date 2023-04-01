namespace VenueHosting.Contracts.Manus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections);

public record MenuSection(
    string Name,
    string Description,
    List<ManuItem> Items);


public record ManuItem(
    string Name,
    string Description);


