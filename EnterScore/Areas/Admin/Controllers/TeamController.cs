using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Conrete.EntityFramework;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly ICoachService _coachService;

        public TeamController(ITeamService teamService, ICoachService coachService)
        {
            _teamService = teamService;
            _coachService = coachService;
        }

        public IActionResult Index()
        {

            List<Coach> CoachLists = _coachService.TGetListAll();
            ViewBag.CoachList = CoachLists;
            var values = _teamService.TGetListAll();
            
            return View(values);
        }
        [HttpGet]

        public IActionResult AddTeam()
        {
            List<Coach> CoachLists = _coachService.TGetListAll();
            ViewBag.CoachList = CoachLists;
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.TInsert(team);
            return RedirectToAction("Team", "Admin");

        }
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.TGetById(id);
            _teamService.TDelete(values);
            return RedirectToAction("Team", "Admin");

        }


        [HttpGet]
        public IActionResult TeamUpdate(int id)
        {
            var values = _teamService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult TeamUpdate(Team p)
        {
            _teamService.TUpdate(p);
            return RedirectToAction("Team", "Admin");


        }
    }
}

