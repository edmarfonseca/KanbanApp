using KanbanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApp.Domain.Dtos.Responses
{
    public class TarefaResponse
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public StatusResponse? Status { get; set; }
    }

    public class StatusResponse
    {
        public int Valor { get; set; }
        public string? Nome { get; set; }
    }
}
