using ErrorOr;
using MediatR;
using VenueHosting.Domain.Menu;

namespace VenueHosting.Application.Features.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<ManuItemCommand> Items);


public record ManuItemCommand(
    string Name,
    string Description);