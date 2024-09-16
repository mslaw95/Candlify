using Candlify.Application.Contracts.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Candlify.Persistence.Repositories
{
    public class BaseRepository<T>(MongoDbContext<T> dbContext) : IBaseRepository<T>
        where T : class
    {
        protected readonly IMongoCollection<T> Collection = dbContext.GetCollection();

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<T>> ListAllAsync()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
            var idProperty = typeof(T).GetProperty("Id");
            var entityId = idProperty?.GetValue(entity);
            if (entityId == null || entityId.Equals(ObjectId.Empty))
            {
                throw new Exception("Failed to insert candle into the Database. No Id generated.");
            }

            return entity;
        }

        public async Task<T> UpdateByIdAsync(Guid id, T entity)
        {
            var result = await Collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
            if (!result.IsAcknowledged)
            {
                throw new Exception("Failed to update candle.");
            }

            return entity;
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            await Collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }
    }
}
