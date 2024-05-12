using Microsoft.AspNetCore.Mvc;
using Rota_InformaticProject.Models;
using System.Diagnostics;

namespace Rota_InformaticProject.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
