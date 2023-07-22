using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
