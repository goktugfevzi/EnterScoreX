using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamListController : Controller
    {

        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly ICloudStorageService _cloudStorageService;

        public TeamListController(ITeamService teamService, IPlayerService playerService, ICloudStorageService cloudStorageService)
        {
            _teamService = teamService;
            _playerService = playerService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = _teamService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);

            }
            return View(values);
        }

        [HttpGet]
        public IActionResult PlayerList(int id)
        {
            var values = _playerService.TGetPlayersByTeamID(id);
            return View(values);
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
