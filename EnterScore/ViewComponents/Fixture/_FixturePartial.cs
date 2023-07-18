using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Fixture
{
    public class _FixturePartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
