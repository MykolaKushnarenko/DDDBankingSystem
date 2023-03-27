using Microsoft.AspNetCore.Mvc;

namespace VenueHosting.Api.Host.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult Diners()
    {
        return Ok(Array.Empty<string>());
    }
}