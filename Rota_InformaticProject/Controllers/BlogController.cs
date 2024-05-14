using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _db;

        public BlogController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Blogs.GetAll().ToList());
        }
        public IActionResult BlogDetails(Guid id)
        {
            var detail = _db.Blogs.GetById(id);
            if (detail==null)
            {
                return NotFound();  

            }
            return View(detail);
        }
    }
}
