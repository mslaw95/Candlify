using Candlify.Application.Responses;
using Candlify.Domain.Entities;

namespace Candlify.Application.Features.Candles.Commands.CreateCandle
{
    public class CreateCandleCommandResponse: BaseResponse
    {
        public CandleVm? CandleVm { get; set; } = default;

        public CreateCandleCommandResponse() : base()
        {
        }
    }
}
