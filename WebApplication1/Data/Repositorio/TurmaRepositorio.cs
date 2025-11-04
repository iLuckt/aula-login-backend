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

    public List<Turma> BuscarTurmas()
    {
        return _bancoContexto.Turma.ToList();
    }

    public Turma? BuscarTurmasPorId(int id)
    {
        return _bancoContexto.Turma.FirstOrDefault(x => x.Id == id);
    }

    public void CadastrarTurma(Turma turma)
    {
        _bancoContexto.Turma.Add(turma);
        _bancoContexto.SaveChanges();
    }

    public void EditarTurma(int id, Turma turma)
    {
        Turma? turmaPorId = BuscarTurmasPorId(id);
        if (turmaPorId == null) throw new Exception("Houve um erro na edição da turma.");
        turmaPorId.Nome = turma.Nome;
        turmaPorId.DataInicio = turma.DataInicio;
        turmaPorId.DataFim = turma.DataFim;
        _bancoContexto.Turma.Update(turmaPorId);
        _bancoContexto.SaveChanges();
    }

    public void ExcluirTurma(int id)
    {
        Turma? turmaPorId = BuscarTurmasPorId(id);
        if (turmaPorId == null) throw new Exception("Houve um erro na exclusão da turma.");
        _bancoContexto.Turma.Remove(turmaPorId);
        _bancoContexto.SaveChanges();
    }
}