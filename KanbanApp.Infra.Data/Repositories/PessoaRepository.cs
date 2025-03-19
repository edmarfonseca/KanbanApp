using KanbanApp.Domain.Entities;
using KanbanApp.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace KanbanApp.Infra.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa, Guid>, IPessoaRepository
    {
        public PessoaRepository() : base("Pessoas")
        {            
        }

        public bool VerifyExists(string email)
        {
            var filter = Builders<Pessoa>.Filter.Eq(p => p.Email, email);
            return _context.Collection.Find(filter).Any();
        }

        public Pessoa? Get(string email, string senha)
        {
            var filter = Builders<Pessoa>.Filter.Eq(p => p.Email, email)
                       & Builders<Pessoa>.Filter.Eq(p => p.Senha, senha);

            return _context.Collection.Find(filter).FirstOrDefault();
        }
    }
}