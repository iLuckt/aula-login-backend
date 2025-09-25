using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
