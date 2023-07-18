using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Profiles
{
    public class _ProfilesDetailPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
