using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayerDemoController : Controller
    {
        private readonly IPlayerService _playerService;
        public PlayerDemoController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult PlayerDemo(int id)
        {
            var players = _playerService.TGetListAll();
            List<Player> teamPlayers = players.Where(player => player.TeamID == id).ToList();

            ViewBag.TeamPlayers = teamPlayers;
            return View();
        }
    }
}
