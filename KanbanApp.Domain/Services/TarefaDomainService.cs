using KanbanApp.Domain.Dtos.Requests;
using KanbanApp.Domain.Dtos.Responses;
using KanbanApp.Domain.Entities;
using KanbanApp.Domain.Interfaces.Repositories;
using KanbanApp.Domain.Interfaces.Services;
using KanbanApp.Domain.Validations;
using FluentValidation;

namespace KanbanApp.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public TarefaResponse Criar(TarefaRequest request, Guid pessoaId)
        {
            var tarefa = new Tarefa
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo,
                DataHora = request.DataHora,
                Descricao = request.Descricao,
                Status = (Status) request.Status,
                PessoaId = pessoaId
            };

            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _tarefaRepository.Add(tarefa);

            return GetResponse(tarefa);
        }

        public TarefaResponse Alterar(Guid tarefaId, TarefaRequest request, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId, pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");

            tarefa.Titulo = request.Titulo;
            tarefa.DataHora = request.DataHora;
            tarefa.Descricao = request.Descricao;
            tarefa.Status = (Status)request.Status;

            var validator = new TarefaValidator();
            var result = validator.Validate(tarefa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _tarefaRepository.Update(tarefaId, tarefa);

            return GetResponse(tarefa);
        }

        public TarefaResponse Excluir(Guid tarefaId, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId, pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");

            _tarefaRepository.Delete(tarefaId);

            return GetResponse(tarefa);
        }

        public List<TarefaResponse> Consultar(DateTime dataMin, DateTime dataFim, Guid pessoaId)
        {
            var lista = _tarefaRepository.Get(dataMin, dataFim, pessoaId);

            var response = new List<TarefaResponse>();
            foreach (var item in lista)
            {
                response.Add(GetResponse(item));
            }

            return response;
        }

        public TarefaResponse Obter(Guid tarefaId, Guid pessoaId)
        {
            var tarefa = _tarefaRepository.Get(tarefaId, pessoaId);
            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada. Verifique o ID informado.");

            return GetResponse(tarefa);
        }

        private TarefaResponse GetResponse(Tarefa tarefa)
        {
            var response = new TarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                DataHora = tarefa.DataHora,
                Descricao = tarefa.Descricao,
                Status = new StatusResponse
                {
                    Valor = (int)tarefa.Status,
                    Nome = tarefa.Status.ToString().Replace("AA", "A ")
                }
            };

            return response;
        }
    }
}