using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetWinningNameService _winningNameService;

        public HomeController (IGetWinningNameService winningNameService)
        {
            _winningNameService = winningNameService;    
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(HomeModel model)
        {
            var test = model;
            var winningName = _winningNameService.GetWinningName(model.EnteredNames);
            return RedirectToAction("Index", "Winner", new { name = winningName.Name });
        }
    }
}