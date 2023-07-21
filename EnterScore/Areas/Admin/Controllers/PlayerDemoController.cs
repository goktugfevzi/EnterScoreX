using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    public class PlayerDemoController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
