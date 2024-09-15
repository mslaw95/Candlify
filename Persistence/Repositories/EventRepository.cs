using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using MongoDB.Driver;

namespace Candlify.Persistence.Repositories
{
    public class EventRepository(MongoDbContext<Event> dbContext) : BaseRepository<Event>(dbContext), IEventRepository
    {
        //TODO
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
