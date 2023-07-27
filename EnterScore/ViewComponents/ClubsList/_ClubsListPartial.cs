using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.ClubsList
{
    public class _ClubsListPartial : ViewComponent
    {
        private readonly ITeamService _teamService;

        public _ClubsListPartial(ITeamService teamService)
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
