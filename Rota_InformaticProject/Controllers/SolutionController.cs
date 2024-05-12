using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class SolutionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SolutionDetails()
        {
            return View();
        }
    }
}
