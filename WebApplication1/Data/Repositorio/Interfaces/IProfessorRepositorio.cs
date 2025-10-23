using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface IProfessorRepositorio
    {

        public void CadastrarProfessor(Professores professores);
        public IEnumerable<Professores> BuscarTodosProfessores();
        public void EditarProfessor(int id, Professores professores);
        public void ExcluirProfessor(int id);
        public IEnumerable<Professores> ListarTodos();
    }
}
