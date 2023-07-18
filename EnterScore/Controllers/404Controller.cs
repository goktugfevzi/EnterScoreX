using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class _404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
