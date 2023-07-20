using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RefereeController : Controller
    {
        private readonly IRefereeService _refereeService;

        public RefereeController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        public IActionResult Index()
        {
            var values = _refereeService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddReferee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReferee(Referee p)
        {
            _refereeService.TInsert(p);
            return RedirectToAction("Referee", "Admin");

        }
        public IActionResult DeleteReferee(int id)
        {
            var value = _refereeService.TGetById(id);
            _refereeService.TDelete(value);
            return RedirectToAction("Referee", "Admin");

        }



        [HttpGet]
        public ActionResult UpdateReferee(int id)
        {
            var value = _refereeService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReferee(Referee p)
        {

            _refereeService.TUpdate(p);
            return RedirectToAction("Referee","Admin");
        }
    }
}
