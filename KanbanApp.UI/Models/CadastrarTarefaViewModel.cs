using System.ComponentModel.DataAnnotations;

namespace KanbanApp.UI.Models
{
    public class CadastrarTarefaViewModel
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o título da tarefa.")]
        public string? Titulo { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora da tarefa.")]
        public string DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe o status da tarefa.")]
        public string? Status { get; set; }
    }
}