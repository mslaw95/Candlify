using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Candlify.Persistence
{
    public class MongoDbContext<T>
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public MongoDbContext(IMongoClient client, string databaseName, string collectionName)
        {
            _database = client.GetDatabase(databaseName);
            _collectionName = collectionName;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(_collectionName);
        }
    }
}
