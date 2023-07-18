using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.TurnamentHistory
{
    public class _Next2MatchPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
