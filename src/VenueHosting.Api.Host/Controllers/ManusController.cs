using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VenueHosting.Application.Features.Menus.Commands.CreateMenu;
using VenueHosting.Contracts.Manus;
using VenueHosting.Domain.Menu;

namespace VenueHosting.Api.Host.Controllers;

[Route("host/{hostId}/menus")]
public class ManusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public ManusController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        CreateMenuCommand command = _mapper.Map<CreateMenuCommand>((request, hostId));
        ErrorOr<Menu> menu = await _sender.Send(command);
        return menu.Match(Ok, Problem);
    }
}