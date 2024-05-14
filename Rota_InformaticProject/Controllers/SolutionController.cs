using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class SolutionController : Controller
    {
        private readonly IUnitOfWork _db;

        public SolutionController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Solutions.GetAll().ToList());
        }
        public IActionResult SolutionDetails(Guid id)
        {
            var detail = _db.Solutions.GetById(id);
            if (detail == null)
            {
                return NotFound();  
            }
            return View(detail);
        }
    }
}
