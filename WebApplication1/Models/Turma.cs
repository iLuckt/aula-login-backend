namespace WebApplication1.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
