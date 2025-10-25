namespace WebApplication1.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public int IdTurma { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public DateOnly DataNascimento { get; set; }
        public int Cpf { get; set; }
        public int Cep { get; set; }
        public string Endereco { get; set; }    
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
    }
}