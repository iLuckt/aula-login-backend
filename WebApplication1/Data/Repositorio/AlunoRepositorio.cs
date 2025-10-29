using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

public class AlunoRepositorio : IAlunoRepositorio
{

    private readonly BancoContexto _bancoContexto;

    public AlunoRepositorio(BancoContexto bancoContexto)
    {
        _bancoContexto = bancoContexto;
    }

    public void CadastrarAluno(Aluno aluno)
    {
        _bancoContexto.Aluno.Add(aluno);
        _bancoContexto.SaveChanges();
    }

    public void EditarAluno(int id, Aluno aluno)
    {
        aluno.Id = id;

        _bancoContexto.Aluno.Update(aluno);
        _bancoContexto.SaveChanges();
    }

    public void ExcluirAluno(int id)
    {
        var aluno = _bancoContexto.Aluno.FirstOrDefault(a => a.Id == id);
        if (aluno != null)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
    }

    public Aluno? BuscarAlunoPorId(int id)
    {
        return _bancoContexto.Aluno.FirstOrDefault(a => a.Id == id);
    }

    public bool TemAlunoComMatricula(int matricula)
    {
        return _bancoContexto.Aluno.Any(a => a.Matricula == matricula);
    }
    public bool TemAlunoComCpf(int cpf)
    {
        return _bancoContexto.Aluno.Any(a => a.Cpf == cpf);
    }

    public IEnumerable<Aluno> ListarTodos()
    {
        return _bancoContexto.Aluno.ToList();
    }
}