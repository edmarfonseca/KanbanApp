using KanbanApp.Domain.Dtos.Requests;
using KanbanApp.Domain.Dtos.Responses;

namespace KanbanApp.Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        TarefaResponse Criar(TarefaRequest request, Guid pessoaId);

        TarefaResponse Alterar(Guid tarefaId, TarefaRequest request, Guid pessoaId);

        TarefaResponse Excluir(Guid tarefaId, Guid pessoaId);

        List<TarefaResponse> Consultar(DateTime dataMin, DateTime dataFim, Guid pessoaId);

        TarefaResponse Obter(Guid tarefaId, Guid pessoaId);
    }
}
