using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Services.GetAll().ToList());
        }
        public IActionResult ServiceDetails(Guid id)
        {
            var detail=_unitOfWork.Services.GetById(id);
            if (detail == null)
            {
                return NotFound();  
            }

            return View(detail);
        }
    }
}
