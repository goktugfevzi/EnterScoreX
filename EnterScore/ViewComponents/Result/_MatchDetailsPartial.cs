using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Result
{
    public class _MatchTodayPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
