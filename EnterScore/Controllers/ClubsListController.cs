using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ClubsListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
