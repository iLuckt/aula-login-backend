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

    public List<Aluno> BuscarTodosAlunos()
    {
        return _bancoContexto.Aluno.ToList();
    }


}