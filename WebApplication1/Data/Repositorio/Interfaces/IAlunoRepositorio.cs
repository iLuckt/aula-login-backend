using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {

        public void CadastrarAluno(Aluno aluno);
        public List<Aluno> BuscarTodosAlunos();
    }
}
