namespace KanbanApp.UI.Dtos
{
    public class TarefaResponseDto
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