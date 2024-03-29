using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RangerEventManager.WebApi.Settings;

namespace RangerEventManager.WebApi.Repositories
{
    public abstract class BaseRepository<TEntity>
    {

        public IMongoCollection<TEntity> Collection;

        public BaseRepository(
            IOptions<MongoDbSettings> dbSettings,
            string collectionName)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            Collection = database.GetCollection<TEntity>(collectionName);

        }
    }
}
