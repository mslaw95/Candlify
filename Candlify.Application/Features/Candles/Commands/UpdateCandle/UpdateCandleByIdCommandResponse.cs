using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candlify.Application.Responses;
using Candlify.Domain.Entities;

namespace Candlify.Application.Features.Candles.Commands.UpdateCandle
{
    public class UpdateCandleByIdCommandResponse : BaseResponse
    {
        public CandleVm? CandleVm{ get; set; } = default;

        public UpdateCandleByIdCommandResponse() : base()
        {
        }
    }
}
