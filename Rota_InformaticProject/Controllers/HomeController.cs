using Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Rota_InformaticProject.Models;
using System.Diagnostics;

namespace Rota_InformaticProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;

        public HomeController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Blogs.GetAll().ToList());
        }

    }
}
