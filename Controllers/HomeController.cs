using Microsoft.AspNetCore.Mvc;
using CoreSite.Services;

namespace CoreSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetHomeModels _homeModelService;

        public HomeController (IGetHomeModels homeModelService)
        {
            _homeModelService = homeModelService;        
        }

        public IActionResult Index()
        {
            var model = _homeModelService.GetHomeModel();
            return View(model);
        }

        public string Welcome()
        {
            return "This is the home Welcome action method...";
        }
    }
}