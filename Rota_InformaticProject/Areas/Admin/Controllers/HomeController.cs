using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
