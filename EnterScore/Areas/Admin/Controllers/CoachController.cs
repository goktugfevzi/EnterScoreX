using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoachController : Controller
    {
        private readonly ICoachService _coachService;

        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }
        public IActionResult Index()
        {
            var values = _coachService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCoach()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCoach(Coach p)
        {
            _coachService.TInsert(p);
            return RedirectToAction("Coach", "Admin");

        }
        public IActionResult DeleteCoach(int id)
        {
            var value = _coachService.TGetById(id);
            _coachService.TDelete(value);
            return RedirectToAction("Coach", "Admin");

        }

        [HttpGet]
        public ActionResult UpdateCoach(int id)
        {
            var value = _coachService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCoach(Coach p)
        {

            _coachService.TUpdate(p);
            return RedirectToAction("Coach", "Admin");
        }
    }
}
