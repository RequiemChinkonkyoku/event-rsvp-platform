using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Entities;
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

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest request)
    {
        var response = await _eventService.CreateEventAsync(request);
        return Ok(new ApiResponse<EventResponse> { Success = true, Data = response });
    }
}