using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        public IActionResult Index(string? searchTerm)
        {
            var lista = _professorRepositorio.ListarTodos() ?? new List<Professores>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                lista = lista
                    .Where(p => p.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(lista);
        }

        public IActionResult AdicionarProfessor()
        {
            return View();
        }

        public IActionResult Cadastrar(Professores professores)
        {
            if (string.IsNullOrEmpty(professores.Nome))
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nulo ou vazio.";
                return View("AdicionarProfessor", professores);
            }

            if (string.IsNullOrEmpty(professores.Email))
            {
                TempData["ErroEmailInvalido"] = "Você inseriu um email inválido";
                return View("AdicionarProfessor", professores);
            }

            if (string.IsNullOrEmpty(professores.Disciplina))
            {
                TempData["ErroDisciplinaInvalida"] = "Você inseriu uma disciplina inválida";
                return View("AdicionarProfessor", professores);
            }

            _professorRepositorio.CadastrarProfessor(professores);
            TempData["Mensagem"] = "Professor cadastrado com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult EditarProfessor(int id)
        {
            var professor = _professorRepositorio.BuscarTodosProfessores().FirstOrDefault(p => p.Id == id);
            if (professor == null)
                return NotFound();

            return View(professor);
        }

        public IActionResult Editar(int id, Professores professores)
        {
            _professorRepositorio.EditarProfessor(id, professores);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            _professorRepositorio.ExcluirProfessor(id);
            return RedirectToAction("Index");
        }
    }
}
