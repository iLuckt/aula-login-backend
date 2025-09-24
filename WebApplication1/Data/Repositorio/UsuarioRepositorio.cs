using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

public class UsuarioRepositorio : IUsuarioRepositorio
{

    private readonly BancoContexto _bancoContexto;

    public UsuarioRepositorio(BancoContexto bancoContexto)
    {
        _bancoContexto = bancoContexto;
    }

    public void CadastrarUsuario(Usuario usuario)
    {
        _bancoContexto.Usuario.Add(usuario);
        _bancoContexto.SaveChanges();
    }

    public Usuario ValidarUsuario(Usuario usuario)
    {
        return _bancoContexto.Usuario.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
    }
}