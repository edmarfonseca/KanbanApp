using KanbanApp.Domain.Entities;

namespace KanbanApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository : IBaseRepository<Tarefa, Guid>
    {
        List<Tarefa> Get(DateTime dataMin, DateTime dataMax, Guid pessoaId);

        Tarefa? Get(Guid tarefaId, Guid pessoaId);
    }
}
