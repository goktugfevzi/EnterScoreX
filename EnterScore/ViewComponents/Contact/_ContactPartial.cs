using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Contact
{
    public class _ContactPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
