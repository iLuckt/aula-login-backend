using WebApplication1.Models;

namespace WebApplication1.Data.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {

        public void CadastrarUsuario(Usuario usuario);
        public Usuario ValidarUsuario(Usuario usuario);
    }
}
