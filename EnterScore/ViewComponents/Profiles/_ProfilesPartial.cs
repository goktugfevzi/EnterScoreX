using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Profiles
{
    public class _ProfilesPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
