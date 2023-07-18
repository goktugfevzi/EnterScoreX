using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Controllers
{
    public class TurnamentHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
    }
}
