using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContacttController : Controller
    {
        private readonly IContactService _contactService;

        public ContacttController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateContactt(int id)
        {
            var value = _contactService.TGetById(id);
            return View(value);
          
        }
        [HttpPost]  
        public ActionResult UpdateContactt(Contact p)
        {

            _contactService.TUpdate(p);
            return RedirectToAction("Contactt", "Admin");
        }
    }
}
