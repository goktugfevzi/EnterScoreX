using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.PlayerList
{
    public class _ProfilesTrail : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public _ProfilesTrail(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        public IViewComponentResult Invoke(int id)
        {
       
            var values = _playerService.TGetPlayersByTeamID(id);
            return View(values);
        }
    }
}
