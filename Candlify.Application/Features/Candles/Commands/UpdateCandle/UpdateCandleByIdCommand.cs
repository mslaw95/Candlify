using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.UpdateCandle
{
    public class UpdateCandleByIdCommand : IRequest<UpdateCandleByIdCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Scent { get; set; } = string.Empty;
        public uint BurnTime { get; set; }
        public uint Capacity { get; set; }
        public uint Height { get; set; }
        public uint Width { get; set; }
    }
}
