using Candlify.Application.Contracts.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Candlify.Persistence.Repositories
{
    public class BaseRepository<T>(MongoDbContext<T> dbContext) : IBaseRepository<T>
        where T : class
    {
        private readonly IMongoCollection<T> _collection = dbContext.GetCollection<T>();

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("id", id)).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> ListAllAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("id", id), entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("id", id));
        }
    }
}
