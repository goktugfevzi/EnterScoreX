using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
