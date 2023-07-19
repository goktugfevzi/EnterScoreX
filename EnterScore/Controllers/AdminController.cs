using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
