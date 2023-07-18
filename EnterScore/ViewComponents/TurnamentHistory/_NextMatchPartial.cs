using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.TurnamentHistory
{
    public class _NextMatchPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
