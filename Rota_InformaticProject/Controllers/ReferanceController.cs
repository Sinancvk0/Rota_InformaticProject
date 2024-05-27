using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class ReferanceController : Controller
    {
        private readonly IUnitOfWork _db;

        public ReferanceController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.References.GetAll().ToList());
        }
    }
}
