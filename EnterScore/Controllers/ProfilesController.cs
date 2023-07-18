using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
