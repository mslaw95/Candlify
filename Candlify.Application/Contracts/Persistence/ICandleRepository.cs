using Candlify.Domain.Entities;

namespace Candlify.Application.Contracts.Persistence
{
    public interface ICandleRepository : IBaseRepository<Candle>
    {
        Task<bool> IsCandleNameUnique(string name);
    }
}
