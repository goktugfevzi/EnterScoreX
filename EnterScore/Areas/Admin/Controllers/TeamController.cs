using BusinessLayer.Abstract;
using EnterScore.Areas.Admin.Method;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly ICoachService _coachService;
        private readonly IStadiumService _stadiumService;
        private readonly ICloudStorageService _cloudStorageService;

        public TeamController(ITeamService teamService, ICoachService coachService, IStadiumService stadiumService, ICloudStorageService cloudStorageService)
        {
            _teamService = teamService;
            _coachService = coachService;
            _stadiumService = stadiumService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = _teamService.TGetTeamsWithCoach();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);

            }
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
        public async Task<IActionResult> AddTeam(Team p)
        {
            if (p.Photo != null)
            {
                p.SavedFileName = GeneratedFileNameForCloud.GenerateFileNameToSave(p.Photo.FileName);
                p.SavedUrl = await _cloudStorageService.UploadFileAsync(p.Photo, p.SavedFileName);
            }
            _teamService.TInsert(p);
            return RedirectToAction("Team", "Admin");
        }


        public async Task<IActionResult> DeleteTeam(int id)
        {
            var value = _teamService.TGetById(id);
            if (value != null)
            {
                if (!string.IsNullOrWhiteSpace(value.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(value.SavedFileName);
                    value.SavedFileName = String.Empty;
                    value.SavedUrl = String.Empty;
                }
                _teamService.TDelete(value);
            }
            return RedirectToAction("Team", "Admin");

        }
        [HttpGet]
        public async Task<IActionResult> TeamUpdate(int id)
        {
            List<Coach> CoachLists = _coachService.TGetListAll();
            ViewBag.CoachList = CoachLists;
            List<Stadium> StadiumLists = _stadiumService.TGetListAll();
            ViewBag.StadiumList = StadiumLists;

            var value = _teamService.TGetById(id);
            await GenerateSignedUrl(value);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> TeamUpdate(Team p)
        {
            if (p.Photo != null)
            {
                await ReplacePhoto(p);
            }
            else
            {
                var existingTeam = _teamService.TGetById(p.TeamID);
                p.SavedUrl = existingTeam.SavedUrl;
                p.SavedFileName = existingTeam.SavedFileName;
            }
            _teamService.TUpdate(p);
            return RedirectToAction("Team", "Admin");

        }


        private async Task ReplacePhoto(Team p)
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
        public async Task GenerateSignedUrl(Team p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}
