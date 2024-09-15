using MediatR;
using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;

namespace Candlify.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQueryHandler(IMapper mapper, IBaseRepository<Event> eventRepository)
        : IRequestHandler<GetEventsListQuery, List<EventsListVm>>
    {
        public async Task<List<EventsListVm>> Handle(GetEventsListQuery request,
            CancellationToken cancellationToken)
        {
            var events = (await eventRepository.ListAllAsync()).OrderBy(x => x.Name);
            return mapper.Map<List<EventsListVm>>(events);
        }
    }
}
