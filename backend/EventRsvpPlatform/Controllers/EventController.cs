using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace EventRsvpPlatform.Controllers;

[ApiController]
[Route("/api/events")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEvents()
    {
        var response = "null";
        return Ok(response);
    }
}