using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ResultController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            TempData["id"] = id;
            return View();
        }
    }
}
