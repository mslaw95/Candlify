using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using MongoDB.Driver;

namespace Candlify.Persistence.Repositories
{
    public class CandleRepository(MongoDbContext<Candle> dbContext) : BaseRepository<Candle>(dbContext), ICandleRepository
    {
        public async Task<bool> IsCandleNameUnique(string name)
        {
            return (await Collection.FindAsync(c => c.Name == name)).FirstOrDefault() != null;
        }
    }
}
