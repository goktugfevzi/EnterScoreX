using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class CoomingSoonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
