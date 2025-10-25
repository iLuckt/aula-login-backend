using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

public class AlunoRepositorio : ITurmaRepositorio
{

    private readonly BancoContexto _bancoContexto;

    public AlunoRepositorio(BancoContexto bancoContexto)
    {
        _bancoContexto = bancoContexto;
    }

    public void CadastrarAluno(Turma aluno)
    {
        _bancoContexto.Aluno.Add(aluno);
        _bancoContexto.SaveChanges();
    }

    public void EditarAluno(int id, Turma aluno)
    {
        aluno.Id = id;

        _bancoContexto.Aluno.Update(aluno);
        _bancoContexto.SaveChanges();
    }

    public void ExcluirAluno(int id)
    {
        var aluno = _bancoContexto.Aluno.FirstOrDefault((System.Linq.Expressions.Expression<Func<Turma, bool>>)(a => a.Id == id));
        if (aluno != null)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
    }

    public IEnumerable<Turma> BuscarTodosAlunos()
    {
        return _bancoContexto.Aluno.ToList();
    }

    public bool TemAlunoComMatricula(int matricula)
    {
        return _bancoContexto.Aluno.Any(a => a.Matricula == matricula);
    }
    public bool TemAlunoComCpf(int cpf)
    {
        return _bancoContexto.Aluno.Any(a => a.Cpf == cpf);
    }

    public IEnumerable<Turma> ListarTodos()
    {
        return _bancoContexto.Aluno.ToList();
    }
}