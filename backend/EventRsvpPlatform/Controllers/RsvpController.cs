using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace EventRsvpPlatform.Controllers;

[ApiController]
[Route("/api/rsvps")]
public class RsvpController : ControllerBase
{
    private readonly IRsvpService _rsvpService;

    public RsvpController(IRsvpService rsvpService)
    {
        _rsvpService = rsvpService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllRsvps()
    {
        var response = "null";
        return Ok(response);
    }
}