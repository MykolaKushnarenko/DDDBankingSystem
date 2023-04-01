using ErrorOr;
using MediatR;
using VenueHosting.Application.Common.Persistence;
using VenueHosting.Domain.Host.ValueObjects;
using VenueHosting.Domain.Menu;
using VenueHosting.Domain.Menu.Entities;

namespace VenueHosting.Application.Features.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuStore _store;

    public CreateMenuCommandHandler(IMenuStore store)
    {
        _store = store;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.ConvertAll(x => MenuSection.Create(
                x.Name,
                x.Description,
                x.Items.ConvertAll(i => MenuItem.Create(
                    i.Name,
                    i.Description)).ToList())).ToList());

        _store.Add(menu);

        return menu;
    }
}