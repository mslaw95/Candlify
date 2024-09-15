using Candlify.Domain.Common;

namespace Candlify.Domain.Entities
{
    public class Event : MetadataEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
