using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface ITurmaRepositorio
    {
        public Turma? BuscarTurmasPorId(int id);
        public List<Turma> BuscarTurmas();
        public void CadastrarTurma(Turma turma);
        public void EditarTurma(int id, Turma turma);
        public void ExcluirTurma(int id);
    }
}