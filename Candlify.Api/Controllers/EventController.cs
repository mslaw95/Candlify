using Candlify.Application.Features.Events.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candlify.Api.Controllers
{
    [ApiController]
    public class EventController(IMediator _mediator): ControllerBase
    {
        [HttpGet("all", Name = "GetAllEvents")]
        public async Task<ActionResult<List<EventsListVm>>> GetAllEventsAsync()
        {
            var result  = await _mediator.Send(new GetEventsListQuery());
            return Ok(result);
        }
    }
}
