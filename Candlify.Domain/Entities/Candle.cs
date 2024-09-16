namespace Candlify.Domain.Entities
{
    public class Candle : BaseProduct
    {
        public string Scent { get; set; } = string.Empty;
        public uint BurnTime { get; set; }
        public uint Capacity { get; set; }
        public uint Height { get; set; }
        public uint Width {get; set; }
    }
}
