using Data.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SolutionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SolutionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {

            return Json(_unitOfWork.Solutions.GetAll().ToList());
        }
        [HttpGet]
        public IActionResult SolutionAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SolutionAdd(Solution solution, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }


                solution.Image = "/images/" + fileName;
            }
            _unitOfWork.Solutions.Add(solution);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult SolutionDelete(Guid id)
        {
            _unitOfWork.Solutions.Remove(id);
            _unitOfWork.Save();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetServiceById(Guid id)
        {
            return Json(_unitOfWork.Solutions.GetById(id));
        }
        [HttpPost]

        public IActionResult UpdateSolution(Solution solution, IFormFile image)
        {
            var existingService = _unitOfWork.Solutions.GetById(solution.Id);
            if (existingService == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(solution.Title))
            {
                existingService.Title = solution.Title;
            }
            if (!string.IsNullOrEmpty(solution.Description))
            {
                existingService.Description = solution.Description;
            }
            if (image != null && image.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                existingService.Image = "/images/" + fileName;
            }
            _unitOfWork.Solutions.Update(existingService);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
