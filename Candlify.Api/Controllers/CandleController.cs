using Candlify.Application.Features.Candles.Commands.CreateCandle;
using Candlify.Application.Features.Candles.Commands.RemoveCandle;
using Candlify.Application.Features.Candles.Commands.UpdateCandle;
using Candlify.Application.Features.Candles.Queries.GetCandleById;
using Candlify.Application.Features.Candles.Queries.GetCandleList;
using Candlify.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Candlify.Api.Controllers
{
    [ApiController]
    [Route("candles")]
    public class CandleController(IMediator _mediator): ControllerBase
    {
        [HttpGet("all", Name = "GetAllCandles")]
        public async Task<ActionResult<List<CandlesListVm>>> GetAllCandlesAsync()
        {
            var result  = await _mediator.Send(new GetCandlesListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCandleById")]
        public async Task<ActionResult<CandleVm>> GetCandleByIdAsync(Guid id)
        {
            var getCandleByIdQuery = new GetCandleByIdQuery() { Id = id };
            var result = await _mediator.Send(getCandleByIdQuery);
            return Ok(result);
        }

        [HttpPost("create", Name = "CreateCandle")]
        public async Task<ActionResult<CandleVm>> CreateCandleAsync([FromBody] CreateCandleCommand createCandleCommand)
        {
            var result = await _mediator.Send(createCandleCommand);
            return Ok(result);
        }

        [HttpPut("{id}", Name = "UpdateCandleById")]
        public async Task<ActionResult<CandleVm>> UpdateCandleByIdAsync(Guid id, [FromBody] UpdateCandleByIdCommand updateCandleByIdCommand)
        {
            updateCandleByIdCommand.Id = id;
            var result = await _mediator.Send(updateCandleByIdCommand);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "RemoveCandleById")]
        public async Task<ActionResult> RemoveCandleByIdAsync(Guid id)
        {
            var removeCandleByIdQuery = new RemoveCandleByIdCommand() { Id = id };
            var result = await _mediator.Send(removeCandleByIdQuery);
            return Ok(result);
        }
    }
}
