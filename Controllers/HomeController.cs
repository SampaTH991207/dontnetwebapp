
using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
        