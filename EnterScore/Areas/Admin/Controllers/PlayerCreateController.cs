using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayerCreateController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IPositionService _positionService;

        public PlayerCreateController(IPlayerService playerService, ITeamService teamService, IPositionService positionService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _positionService = positionService; 
        }

        public IActionResult Index()
        {
            List<Team> TeamLists = _teamService.TGetListAll();
            ViewBag.TeamLists = TeamLists;

            List<Position> PositionLists = _positionService.TGetListAll();
            ViewBag.PositionLists = PositionLists;

            var values = _playerService.TGetListAll();
            return View(values);
        }
        [HttpGet]

        public IActionResult AddPlayer()

        {
            List<Team> TeamLists = _teamService.TGetListAll();
            ViewBag.TeamLists = TeamLists;

            List<Position> PositionLists = _positionService.TGetListAll();
            ViewBag.PositionLists = PositionLists;

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> AddPlayer(Player p, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                p.ImageURL = "/admin_panel/img/" + fileName;
            }


            _playerService.TInsert(p);
            return RedirectToAction("PlayerCreate", "Admin");




        }
        public IActionResult DeletePlayer(int id)
        {
            var values = _playerService.TGetById(id);
            _playerService.TDelete(values);
            return RedirectToAction("PlayerCreate", "Admin");

        }


        [HttpGet]
        public IActionResult PlayerUpdate(int id)
        {
            List<Team> TeamLists = _teamService.TGetListAll();
            ViewBag.TeamLists = TeamLists;

            List<Position> PositionLists = _positionService.TGetListAll();
            ViewBag.PositionLists = PositionLists;


            var values = _playerService.TGetById(id);
            return View(values);
        }

        [HttpPost]

        public async Task<IActionResult> PlayerUpdate(Player player, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var physicalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin_panel", "img", fileName);
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                player.ImageURL = "/admin_panel/img/" + fileName;
            }

            _playerService.TUpdate(player);
            return RedirectToAction("PlayerCreate", "Admin");


        }
    }
}
