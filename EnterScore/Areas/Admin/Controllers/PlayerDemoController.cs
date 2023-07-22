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
        EnterScoreXContext _enterScoreXContext = new EnterScoreXContext();

        public PlayerDemoController(EnterScoreXContext enterScoreXContext)
        {
            _enterScoreXContext = enterScoreXContext;
        }
        [HttpGet]
        public IActionResult PlayerDemo(int id)
        {
                List<Player> players = _enterScoreXContext.Players.ToList();
                List<Player> teamPlayers = players.Where(player => player.TeamID == id).ToList();

                ViewBag.TeamPlayers = teamPlayers;
                return View();
            }
    }
}
