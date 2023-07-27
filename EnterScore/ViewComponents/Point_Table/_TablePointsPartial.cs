using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _TablePointsPartial: ViewComponent
    {
        private readonly ITeamService _teamService;

        public _TablePointsPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public IViewComponentResult Invoke() 
        {
            var values = _teamService.TGetListAll();
            return View(values); 
        } 
    }
}
