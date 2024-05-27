using Data.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReferanceController : Controller
    {
        private readonly IUnitOfWork _db;

        public ReferanceController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_db.References.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Reference reference,IFormFile image)
        {
            if (image !=null && image.Length>0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);
                using(var stream =new FileStream(filePath,FileMode.Create))
                {
                    image.CopyTo(stream);   
                }

                reference.Image = "/images/" + fileName;

            }
           
            _db.References.Add(reference);
            _db.Save();
            return Ok();

        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _db.References.Remove(id);
            _db.Save();
            return Ok();

        }
    }
}
