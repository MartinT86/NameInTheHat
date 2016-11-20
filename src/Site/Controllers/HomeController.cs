using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetHomeModels _homeModelService;
        private readonly IGetWinningNameService _winningNameService;

        public HomeController (IGetHomeModels homeModelService, IGetWinningNameService winningNameService)
        {
            _homeModelService = homeModelService;    
            _winningNameService = winningNameService;    
        }

        public IActionResult Index()
        {
            var model = _homeModelService.GetHomeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeModel model)
        {
            var test = model;
            return RedirectToAction("Index");
        }
    }
}