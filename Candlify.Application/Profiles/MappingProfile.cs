using Candlify.Domain.Entities; 
using AutoMapper;
using Candlify.Application.Features.Events.Commands.CreateEvent;
using Candlify.Application.Features.Events.Queries.GetEventList;

namespace Candlify.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventsListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
        }
    }
}
