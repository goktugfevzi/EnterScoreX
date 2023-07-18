using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class PointTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
