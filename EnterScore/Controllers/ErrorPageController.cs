using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
            Console.WriteLine(code);
            return View();
        }
    }
}
