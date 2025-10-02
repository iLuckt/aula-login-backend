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

        public IActionResult EditarAluno(int id)
        {
            var aluno = _alunoRepositorio.BuscarTodosAlunos().FirstOrDefault(a => a.Id == id);
            return View(aluno);
        }
        public IActionResult Cadastrar(Aluno aluno)
        {
            _alunoRepositorio.CadastrarAluno(aluno);
            return View("Index");
        }
        public IActionResult Editar(int id, Aluno aluno)
        {
            _alunoRepositorio.EditarAluno(id, aluno);
            return View("Index", _alunoRepositorio.BuscarTodosAlunos());
        }
        public IActionResult Excluir(int id)
        {
            _alunoRepositorio.ExcluirAluno(id);
            return View("Index", _alunoRepositorio.BuscarTodosAlunos());
        }
    }
}
