using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Api.Settings;

namespace Api.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client =new MongoClient(settings.Value.connectionString);
            _database =client.GetDatabase(settings.Value.database);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        public IMongoDatabase Database { get { return _database; } }
    }
}
