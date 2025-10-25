using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data.Repositorio.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TurmaController : Controller
    {

        private readonly ITurmaRepositorio _turmaRepositorio;

        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }
        

        public IActionResult AdicionarAluno()
        {
            return View();
        }

        public IActionResult EditarAluno(int id)
        {
            var aluno = _turmaRepositorio.BuscarTodosAlunos().FirstOrDefault(a => a.Id == id);
            return View(aluno);
        }
        public IActionResult Editar(int id, Turma turma)
        {
            _turmaRepositorio.EditarAluno(id, turma);
            return View("Index", _turmaRepositorio.BuscarTodosAlunos());
        }
        public IActionResult Excluir(int id)
        {
            _turmaRepositorio.ExcluirAluno(id);
            return View("Index", _turmaRepositorio.BuscarTodosAlunos());
        }
        public IActionResult Cadastrar(Turma aluno)
        {

            if (aluno.Nome.IsNullOrEmpty())
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nullo ou vazio.";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Matricula == 0)
            {
                TempData["ErroMatriculaInvalida"] = "Você inseriu uma matricula invalida ou com caracteres";
                return View("AdicionarAluno", aluno);
            }

            if (_turmaRepositorio.TemAlunoComMatricula(aluno.Matricula))
            {
                TempData["ErroMatriculaInvalida"] = "Já existe um aluno com essa matricula.";
                return View("AdicionarAluno", aluno);
            }

            // CHANGE TO VARCHAR
            if (aluno.Cpf == 0)
            {
                TempData["ErroCPFInvalida"] = "Você inseriu um cpf invalido";
                return View("AdicionarAluno", aluno);
            }

            if (_turmaRepositorio.TemAlunoComCpf(aluno.Cpf))
            {
                TempData["ErroCPFInvalida"] = "Já existe um aluno com esse cpf.";
                return View("AdicionarAluno", aluno);
            }

            // CHANGE TO VARCHAR
            if (aluno.Cep == 0)
            {
                TempData["ErroCepInvalida"] = "Você inseriu um cep invalido";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Endereco.IsNullOrEmpty())
            {
                TempData["ErroEnderecoInvalida"] = "Você inseriu um endereço invalido.";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Bairro.IsNullOrEmpty())
            {
                TempData["ErroBairroInvalida"] = "Você inseriu um bairro invalido.";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Cidade.IsNullOrEmpty())
            {
                TempData["ErroCidadeInvalida"] = "Você inseriu uma cidade invalida.";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Numero == 0)
            {
                TempData["ErroNumeroInvalida"] = "Você inseriu um numero nulo ou com caracteres.";
                return View("AdicionarAluno", aluno);
            }

            _turmaRepositorio.CadastrarAluno(aluno);
            
            TempData["Mensagem"] = "Aluno cadastrado com sucesso";
            return RedirectToAction("Index");
        }
        public IActionResult Index(string? searchTerm)
        {
            if (!searchTerm.IsNullOrEmpty())
            {
                var alunos = _turmaRepositorio.ListarTodos()
                    .Where(a => a.Nome.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                return View(alunos);
            }

            return View(_turmaRepositorio.ListarTodos());
        }
    }
}
