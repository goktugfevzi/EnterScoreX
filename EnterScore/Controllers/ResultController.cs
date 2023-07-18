using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
