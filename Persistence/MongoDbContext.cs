using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Candlify.Persistence
{
    public class MongoDbContext<T>(IMongoClient client, string databaseName, string collectionName)
    {
        private readonly IMongoDatabase _database = client.GetDatabase(databaseName);

        public IMongoCollection<T> GetCollection()
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
