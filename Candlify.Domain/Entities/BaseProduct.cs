using Candlify.Domain.Common;

namespace Candlify.Domain.Entities
{
    public class BaseProduct : MetadataEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; } // TODO - struct or model
        public int Stock { get; set; }
        public bool IsAvailable => Stock > 0;
        //TODO - Collection of photos
    }
}
