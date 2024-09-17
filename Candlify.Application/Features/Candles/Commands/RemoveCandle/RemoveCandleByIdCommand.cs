using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.RemoveCandle
{
    public class RemoveCandleByIdCommand : IRequest<RemoveCandleByIdCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
