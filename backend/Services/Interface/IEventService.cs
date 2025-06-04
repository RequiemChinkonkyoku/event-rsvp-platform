using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Entities;

namespace Services.Interface;

public interface IEventService
{
    Task<EventResponse> CreateEventAsync(CreateEventRequest request);
}