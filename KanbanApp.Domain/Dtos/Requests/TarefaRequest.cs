using KanbanApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanApp.Domain.Dtos.Requests
{
    public class TarefaRequest
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public int? Status { get; set; }
    }
}
