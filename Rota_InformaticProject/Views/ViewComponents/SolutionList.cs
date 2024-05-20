using Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Rota_InformaticProject.Views.ViewComponents
{
    public class SolutionList:ViewComponent
    {
        private readonly IUnitOfWork _db;

        public SolutionList(IUnitOfWork db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
              return View(_db.Solutions.GetAll().ToList());    
        }
    }
}
