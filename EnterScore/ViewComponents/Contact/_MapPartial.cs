using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Contact
{
    public class _MapPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
