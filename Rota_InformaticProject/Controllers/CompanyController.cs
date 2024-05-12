using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
