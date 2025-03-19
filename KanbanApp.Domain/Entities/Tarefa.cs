using System.ComponentModel;

namespace KanbanApp.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public Status? Status { get; set; }
        public Guid? PessoaId { get; set; }

        public Pessoa? Pessoa { get; set; }
    }

    public enum Status
    {
        AAFazer = 1,
        Fazendo = 2,
        Finalizado = 3
    }
}