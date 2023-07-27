using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Contact
{

    public class _ContactPartial : ViewComponent
    {
     
        private readonly IContactService _contactService;

        public _ContactPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetListAll();
            return View(values);

        }
    }
}
