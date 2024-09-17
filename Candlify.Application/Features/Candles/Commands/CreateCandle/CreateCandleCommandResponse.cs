using Candlify.Application.Models;
using Candlify.Application.Responses;

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
