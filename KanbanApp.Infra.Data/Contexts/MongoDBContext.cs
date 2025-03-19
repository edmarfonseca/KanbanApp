using KanbanApp.Infra.Data.Settings;
using MongoDB.Driver;

namespace KanbanApp.Infra.Data.Contexts
{
    public class MongoDBContext<T> where T : class
    {
        private readonly IMongoDatabase? _database;
        private readonly string? _collectionName;

        public MongoDBContext(string collectionName)
        {
            var clientSettings = MongoClientSettings.FromUrl(new MongoUrl(MongoDBSettings.Host));
            var mongoClient = new MongoClient(clientSettings);

            _database = mongoClient.GetDatabase(MongoDBSettings.Database);
            _collectionName = collectionName;
        }

        public IMongoCollection<T>? Collection {
            get {
                return _database?.GetCollection<T>(_collectionName);
            }            
        }
    }
}