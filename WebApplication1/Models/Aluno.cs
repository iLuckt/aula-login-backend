namespace WebApplication1.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }    
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
    }
}