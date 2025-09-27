using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_alunoRepositorio.BuscarTodosAlunos());
        }

        public IActionResult AdicionarAluno()
        {
            return View();
        }
        public IActionResult Cadastrar(Aluno aluno)
        {
            _alunoRepositorio.CadastrarAluno(aluno);
            return View("Index");
        }
    }
}
