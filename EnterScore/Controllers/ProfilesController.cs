using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index(int id)
        {
            TempData["id2"] = id;
            return View();
        }
    }
}
