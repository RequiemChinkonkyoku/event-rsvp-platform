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
        CreateMap<AccountRequest, Account>();
        
        CreateMap<Event, EventResponse>();
        CreateMap<EventRequest, Event>();
        
        CreateMap<Rsvp, RsvpResponse>();
        CreateMap<RsvpRequest, Rsvp>();
    }
}