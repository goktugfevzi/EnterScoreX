using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = _contactService.TGetById(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateContact(Contact p)
        {

            _contactService.TUpdate(p);
            return RedirectToAction("Contact", "Admin");
        }
    }
}
