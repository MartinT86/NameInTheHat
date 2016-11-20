using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers
{
    public class WinnerController : Controller
    {
        public IActionResult Index(string name)
        {
            if(string.IsNullOrEmpty(name))
                return View("Missing");

            var winnerModel = new WinningNameModel(name);
            return View(winnerModel);
        }
    }
}