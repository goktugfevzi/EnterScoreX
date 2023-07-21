using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
          
            return View();
        }
    }
}
