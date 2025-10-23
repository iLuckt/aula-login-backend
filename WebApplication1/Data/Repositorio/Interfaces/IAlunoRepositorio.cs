using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {

        public void CadastrarAluno(Aluno aluno);
        public IEnumerable<Aluno> BuscarTodosAlunos();
        public void EditarAluno(int id, Aluno aluno);
        public void ExcluirAluno(int id);
        public bool TemAlunoComCpf(int cpf);
        public bool TemAlunoComMatricula(int matricula);
        public IEnumerable<Aluno> ListarTodos();
    }
}
