using Data.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_unitOfWork.Blogs.GetAll().ToList());
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }


                blog.Image = "/images/" + fileName;
            }
            _unitOfWork.Blogs.Add(blog);
            _unitOfWork.Save();
            return RedirectToAction();

        }
        [HttpPost]
        public IActionResult BlogDelete(Guid id)
        {
            _unitOfWork.Blogs.Remove(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
