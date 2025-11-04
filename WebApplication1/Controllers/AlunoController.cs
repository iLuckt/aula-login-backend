using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        

        public IActionResult AdicionarAluno()
        {
            return View();
        }

        public IActionResult EditarAluno(int id)
        {
            var aluno = _alunoRepositorio.BuscarAlunoPorId(id);
            return View(aluno);
        }
        public IActionResult Editar(int id, Aluno aluno)
        {
            _alunoRepositorio.EditarAluno(id, aluno);
            return View("Index", _alunoRepositorio.ListarTodos());
        }
        public IActionResult Excluir(int id)
        {
            _alunoRepositorio.ExcluirAluno(id);
            return View("Index", _alunoRepositorio.ListarTodos());
        }
        public IActionResult CadastrarAluno(Aluno aluno)
        {

            if (aluno.Nome.IsNullOrEmpty())
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nulo ou vazio.";
                return View("AdicionarAluno", aluno);
            }

            _alunoRepositorio.CadastrarAluno(aluno);
            return View("Index", _alunoRepositorio.ListarTodos());
        }

        public IActionResult Index(string? searchTerm)
        {
            if (!searchTerm.IsNullOrEmpty())
            {
                var alunos = _alunoRepositorio.ListarTodos()
                    .Where(t => t.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                return View(alunos);
            }

            return View(_alunoRepositorio.ListarTodos());
        }
    }
}
