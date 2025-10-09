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
        public IActionResult Cadastrar(Aluno aluno)
        {

            if (aluno.Name.IsNullOrEmpty())
            {
                TempData["ErroNomeInvalida"] = "Você inseriu um nome nullo ou vazio.";
                return View("AdicionarAluno", aluno);
            }

            if (aluno.Matricula == 0)
            {
                TempData["ErroMatriculaInvalida"] = "Você inseriu uma matricula invalida ou com caracteres";
                return View("AdicionarAluno", aluno);
            }

            if (_alunoRepositorio.TemAlunoComMatricula(aluno.Matricula))
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

            if (_alunoRepositorio.TemAlunoComCpf(aluno.Cpf))
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

            _alunoRepositorio.CadastrarAluno(aluno);
            
            TempData["Mensagem"] = "Aluno cadastrado com sucesso";
            return RedirectToAction("Index");
        }
    }
}
