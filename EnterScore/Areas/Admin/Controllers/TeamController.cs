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
        private readonly IStadiumService _stadiumService;

        public TeamController(ITeamService teamService, ICoachService coachService, IStadiumService stadiumService)
        {
            _teamService = teamService;
            _coachService = coachService;
            _stadiumService = stadiumService;
        }

        public IActionResult Index()
        {
            var values = _teamService.TGetTeamsWithCoach();
            return View(values);
        }
        [HttpGet]

        public IActionResult AddTeam()
        {
            List<Coach> CoachLists = _coachService.TGetListAll();
            List<Stadium> StadiumLists = _stadiumService.TGetListAll();
            ViewBag.CoachList = CoachLists;
            ViewBag.StadiumList = StadiumLists;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(Team p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.ImageUrl = "/admin_panel/img/" + fileName;
            }
            _teamService.TInsert(p);
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
            List<Coach> CoachLists = _coachService.TGetListAll();
            ViewBag.CoachList = CoachLists;
            List<Stadium> StadiumLists = _stadiumService.TGetListAll();
            ViewBag.StadiumList = StadiumLists;
            var values = _teamService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> TeamUpdate(Team p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.ImageUrl = "/admin_panel/img/" + fileName;
            }
            _teamService.TUpdate(p);
            return RedirectToAction("Team", "Admin");


        }
    }
}

