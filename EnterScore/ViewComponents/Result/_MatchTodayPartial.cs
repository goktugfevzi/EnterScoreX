using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Result
{
    public class _MatchDetailsPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
