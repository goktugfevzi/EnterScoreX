using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        public IActionResult Index()
        {
            var values = _positionService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPosition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPosition(Position p)
        {
            _positionService.TInsert(p);
            return RedirectToAction("Position", "Admin");

        }
        public IActionResult DeletePosition(int id)
        {
            var value = _positionService.TGetById(id);
            _positionService.TDelete(value);
            return RedirectToAction("Position", "Admin");

        }

        [HttpGet]
        public ActionResult UpdatePosition(int id)
        {
            var value = _positionService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdatePosition(Position p)
        {

            _positionService.TUpdate(p);
            return RedirectToAction("Position", "Admin");
        }
    }
}
