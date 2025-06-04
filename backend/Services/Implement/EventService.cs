using AutoMapper;
using Microsoft.Extensions.Configuration;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Entities;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implement;

public class EventService : IEventService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    
    public EventService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _config = config;
    }

    public async Task<EventResponse> CreateEventAsync(CreateEventRequest request)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(request.AccountId);
        if (account == null)
        {
            throw new Exception($"Account {request.AccountId} not found");
        }

        if (request.StartTime.Date <= DateTime.UtcNow.Date)
        {
            throw new Exception($"Start time must be in the future");
        }

        if (request.EndTime.Date <= request.StartTime.Date)
        {
            throw new Exception($"End time must be later than the start time");
        }
        
        var newEvent = _mapper.Map<Event>(request);
        newEvent.Id = Guid.NewGuid();
        
        newEvent.CreatedTime = DateTime.UtcNow;
        newEvent.LastUpdatedTime = DateTime.UtcNow;
        
        await _unitOfWork.Events.AddAsync(newEvent);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<EventResponse>(newEvent);
    }
}