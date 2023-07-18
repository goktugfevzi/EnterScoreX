using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _HeadPartial: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
