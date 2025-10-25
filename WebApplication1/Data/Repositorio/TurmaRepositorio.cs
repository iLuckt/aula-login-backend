using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

public class TurmaRepositorio : ITurmaRepositorio
{

    private readonly BancoContexto _bancoContexto;

    public TurmaRepositorio(BancoContexto bancoContexto)
    {
        _bancoContexto = bancoContexto;
    }

    public Turma? BuscarTurmasPorId(int id)
    {
        return _bancoContexto.Turma.FirstOrDefault(t => t.IdTurma == id);
    }
    public IEnumerable<Turma> BuscarTurmasPorId()
    {
        return _bancoContexto.Turma.ToList();
    }
}