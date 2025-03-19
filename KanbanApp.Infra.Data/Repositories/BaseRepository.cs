using KanbanApp.Domain.Interfaces.Repositories;
using KanbanApp.Infra.Data.Contexts;
using MongoDB.Driver;

namespace KanbanApp.Infra.Data.Repositories
{
    public class BaseRepository<T, ID> : IBaseRepository<T, ID> where T : class
    {
        protected readonly MongoDBContext<T> _context;

        public BaseRepository(string collectionName)
        {
            _context = new MongoDBContext<T>(collectionName);
        }

        public virtual void Add(T obj)
        {
            _context?.Collection?.InsertOne(obj);
        }

        public virtual void Update(ID id, T obj)
        {
            _context?.Collection?.ReplaceOne(Builders<T>.Filter.Eq("_id", id), obj);
        }

        public virtual void Delete(ID id)
        {
            _context?.Collection?.DeleteOne(Builders<T>.Filter.Eq("_id", id));

            /*
            var filter = Builders<T>.Filter.Eq("_id", id);
            var update = Builders<T>.Update.Set("ativo", false);

            _context?.Collection?.UpdateOne(filter, update);
            */
        }

        public virtual List<T> GetAll()
        {
            return _context?.Collection?.Find(_ => true).ToList();
        }

        public virtual T? GetById(ID id)
        {
            return _context?.Collection?.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefault();
        }
    }
}