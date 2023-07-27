using DTOLayer.DTOs.ContactUsDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Contact
{
    public class _ContactUsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new SendMessageDto();
            return View(model);
       
        }
    }
}
