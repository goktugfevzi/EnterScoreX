using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
