using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _TablePointsPartial: ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
