using Data.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ServiceController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		public ServiceController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetAll()
		{
			return Json(_unitOfWork.Services.GetAll());
		}
		[HttpGet]
		public IActionResult ServiceAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult ServiceAdd(Service service, IFormFile image)
		{
			if (image != null && image.Length > 0)
			{

				var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					image.CopyTo(stream);
				}


				service.Image = "/images/" + fileName;
			}
			_unitOfWork.Services.Add(service);
			_unitOfWork.Save();
			return Ok();
		}
		[HttpPost]
		public IActionResult ServiceDelete(Guid id)
		{
			_unitOfWork.Services.Remove(id);
			_unitOfWork.Save();
			return Ok();
		}
		[HttpGet]
		public IActionResult GetServiceById(Guid id)
		{
			return Json(_unitOfWork.Services.GetById(id));
		}
		[HttpPost]

		public IActionResult UpdateService(Service service, IFormFile image)
		{
			var existingService = _unitOfWork.Services.GetById(service.Id);
			if (existingService == null)
			{
				return NotFound();
			}
			if (!string.IsNullOrEmpty(service.Title))
			{
				existingService.Title = service.Title;
			}
			if (!string.IsNullOrEmpty(service.Description))
			{
				existingService.Description = service.Description;
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
			_unitOfWork.Services.Update(existingService);
			_unitOfWork.Save();
			return Ok();
		}

	}
}