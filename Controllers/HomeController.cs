using Microsoft.AspNetCore.Mvc;

namespace LinkUp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}