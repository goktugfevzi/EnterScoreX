using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class FixtureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
