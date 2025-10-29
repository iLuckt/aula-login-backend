using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITurmaRepositorio _turmaRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAlunoRepositorio alunoRepositorio, ITurmaRepositorio turmaRepositorio)
        {
            _logger = logger;
            _alunoRepositorio = alunoRepositorio;
            _turmaRepositorio = turmaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Relatorio()
        {
            var alunos = _alunoRepositorio.ListarTodos();

            var relatorioViewModels = alunos
                .Select(x => new RelatorioViewModel
                {
                    Aluno = x,
                    Turma = _turmaRepositorio.BuscarTurmasPorId(x.IdTurma)
                })
                .ToList();

            return View(relatorioViewModels);
        }


    }
}

