using MediatR;

namespace Candlify.Application.Features.Candles.Commands.CreateCandle
{
    public class CreateCandleCommand : IRequest<CreateCandleCommandResponse>
    {
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
