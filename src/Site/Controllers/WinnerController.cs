using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class WinnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}