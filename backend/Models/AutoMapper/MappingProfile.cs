using AutoMapper;
using Models.DTOs.Request;
using Models.DTOs.Response;
using Models.Entities;

namespace Models.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Account, AccountResponse>();
        CreateMap<CreateAccountRequest, Account>();
        
        CreateMap<Event, EventResponse>();
        CreateMap<CreateEventRequest, Event>();
        
        CreateMap<Rsvp, RsvpResponse>();
        CreateMap<RsvpRequest, Rsvp>();
    }
}