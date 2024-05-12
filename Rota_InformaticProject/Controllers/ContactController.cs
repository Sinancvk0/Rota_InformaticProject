using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
