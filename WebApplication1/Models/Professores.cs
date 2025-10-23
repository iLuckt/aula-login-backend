using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class Professores
    { 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Disciplina { get; set; }
    }
}
