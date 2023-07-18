using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        } 
    }
}
