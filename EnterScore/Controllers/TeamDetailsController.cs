using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class TeamDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
