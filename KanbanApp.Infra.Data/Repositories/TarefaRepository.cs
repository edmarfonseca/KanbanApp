using KanbanApp.Domain.Entities;
using KanbanApp.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace KanbanApp.Infra.Data.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa, Guid>, ITarefaRepository
    {
        public TarefaRepository() : base("Tarefas")
        {            
        }

        public List<Tarefa> Get(DateTime dataMin, DateTime dataMax, Guid pessoaId)
        {
            dataMin = dataMin.Date;
            dataMax = dataMax.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var filter = Builders<Tarefa>.Filter.Eq(t => t.PessoaId, pessoaId)
                       & Builders<Tarefa>.Filter.Gte(t => t.DataHora, dataMin)
                       & Builders<Tarefa>.Filter.Lte(t => t.DataHora, dataMax);

            var sort = Builders<Tarefa>.Sort.Ascending(t => t.DataHora);

            return _context.Collection.Find(filter).Sort(sort).ToList();
        }

        public Tarefa? Get(Guid tarefaId, Guid pessoaId)
        {
            var filter = Builders<Tarefa>.Filter.Eq(t => t.Id, tarefaId)
                      & Builders<Tarefa>.Filter.Eq(t => t.PessoaId, pessoaId);

            return _context.Collection.Find(filter).FirstOrDefault();
        }
    }
}