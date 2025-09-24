using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        
        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                var retorno = _usuarioRepositorio.ValidarUsuario(usuario);

                if (retorno != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MsgErro"] = "Usuário ou senha incorretos! Tente novamente...";
                }
            }
            catch (Exception)
            {
                TempData["MsgErro"] = "Erro ao buscar dados do usuário";
            }
            return View("Index");
        }

        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.CadastrarUsuario(usuario);

                TempData["CadastroOk"] = "Cadastro realizado com sucesso";

                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MsgErro"] = "Erro ao cadastrar o usuário";
            }

            return View("Cadastro");
        }
    }
}
