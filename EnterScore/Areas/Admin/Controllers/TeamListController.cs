using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamListController : Controller
    {

        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public TeamListController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            var values = _teamService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult PlayerList(int id)
        {
            //List<Player> players = _playerService.TGetListAll();
            //List<Player> teamPlayers = players.Where(player => player.TeamID == id).ToList();
            var values = _playerService.TGetPlayersByTeamID(id);

            //ViewBag.TeamPlayers = teamPlayers;
            return View(values);
        }
    }
}
