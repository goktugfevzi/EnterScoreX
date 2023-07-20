using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class StadiumController : Controller
    {

        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }
        public IActionResult Index()
        {
            var values = _stadiumService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddStadium()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStadium(Stadium p)
        {
            _stadiumService.TInsert(p);
            return RedirectToAction("Stadium", "Admin");

        }
        public IActionResult DeleteStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            _stadiumService.TDelete(value);
            return RedirectToAction("Stadium", "Admin");

        }

        [HttpGet]
        public IActionResult UpdateStadium(int id)
        {
            var value = _stadiumService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateStadium(Stadium p)
        {

            _stadiumService.TUpdate(p);
            return RedirectToAction("Stadium", "Admin");
        }
    }
}
