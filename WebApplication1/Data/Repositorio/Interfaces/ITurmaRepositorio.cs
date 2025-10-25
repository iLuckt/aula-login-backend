using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface ITurmaRepositorio
    {
        public IEnumerable<Turma> BuscarTurmasPorId();
        public Turma? BuscarTurmasPorId(int id);
    }
}
