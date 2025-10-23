using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

public class ProfessorRepositorio : IProfessorRepositorio
{

    private readonly BancoContexto _bancoContexto;

    public ProfessorRepositorio(BancoContexto bancoContexto)
    {
        _bancoContexto = bancoContexto;
    }

    public void CadastrarProfessor(Professores professores)
    {
        _bancoContexto.Professores.Add(professores);
        _bancoContexto.SaveChanges();
    }

    public void EditarProfessor(int id, Professores professores)
    {
        professores.Id = id;

        _bancoContexto.Professores.Update(professores);
        _bancoContexto.SaveChanges();
    }

    public void ExcluirProfessor(int id)
    {
        var professores = _bancoContexto.Professores.FirstOrDefault(a => a.Id == id);
        if (professores != null)
        {
            _bancoContexto.Professores.Remove(professores);
            _bancoContexto.SaveChanges();
        }
    }

    public IEnumerable<Professores> BuscarTodosProfessores()
    {
        return _bancoContexto.Professores.ToList();
    }

    public IEnumerable<Professores> ListarTodos()
    {
        return _bancoContexto.Professores.ToList();
    }
}