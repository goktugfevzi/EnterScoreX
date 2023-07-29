using BusinessLayer.Abstract;
using EnterScore.Areas.Admin.Method;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IPositionService _positionService;
        private readonly ICloudStorageService _cloudStorageService;


        public PlayerController(IPlayerService playerService, ITeamService teamService, IPositionService positionService, ICloudStorageService cloudStorageService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _positionService = positionService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> TeamLists = _teamService.TGetListAll();
            ViewBag.TeamLists = TeamLists;

            List<Position> PositionLists = _positionService.TGetListAll();
            ViewBag.PositionLists = PositionLists;

            var values = _playerService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);

            }
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
        public async Task<IActionResult> AddPlayer(Player p)
        {

            if (p.Photo != null)
            {
                p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
            }
            _playerService.TInsert(p);
            return RedirectToAction("Player", "Admin");
        }


        public async Task<IActionResult> DeletePlayer(int id)
        {
            var value = _playerService.TGetById(id);
            if (value != null)
            {
                if (!string.IsNullOrWhiteSpace(value.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                    value.SavedFileName = String.Empty;
                    value.SavedUrl = String.Empty;
                }
                _playerService.TDelete(value);
            }
            return RedirectToAction("Player", "Admin");

        }

        [HttpGet]
        public async Task<IActionResult> PlayerUpdate(int id)
        {
            List<Team> TeamLists = _teamService.TGetListAll();
            ViewBag.TeamLists = TeamLists;

            List<Position> PositionLists = _positionService.TGetListAll();
            ViewBag.PositionLists = PositionLists;


            var values = _playerService.TGetById(id);
            await GenerateSignedUrl(values);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> PlayerUpdate(Player p)
        {
            if (p.Photo != null)
            {
                await ReplacePhoto(p);
            }
            else
            {
                var existingTeam = _playerService.TGetById(p.PlayerID);
                p.SavedUrl = existingTeam.SavedUrl;
                p.SavedFileName = existingTeam.SavedFileName;
            }
            _playerService.TUpdate(p);
            return RedirectToAction("Player", "Admin");

        }
        private async Task ReplacePhoto(Player p)
        {
            if (p.Photo != null)
            {
                if (!string.IsNullOrEmpty(p.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(p.SavedFileName);
                }
                p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
            }
        }
        public async Task GenerateSignedUrl(Player p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}