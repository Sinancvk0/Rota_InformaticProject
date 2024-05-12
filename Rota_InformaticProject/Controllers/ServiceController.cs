using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ServiceDetails()
        {
            return View();
        }
    }
}
