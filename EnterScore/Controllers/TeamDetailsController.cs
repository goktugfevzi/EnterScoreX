using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace EnterScore.Controllers
{
    public class TeamDetailsController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerStatisticService _playerStatisticService;
        private readonly IMatchService _matchService;
        private readonly ICloudStorageService _cloudStorageService;

        public TeamDetailsController(ITeamService teamService, ICloudStorageService cloudStorageService, IPlayerStatisticService playerStatisticService, IMatchService matchService)
        {
            _teamService = teamService;
            _cloudStorageService = cloudStorageService;
            _playerStatisticService = playerStatisticService;
            _matchService = matchService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var team = _teamService.TGetTeamWithCoachById(id);
            var lastMatches = _matchService.TGetTeamLastMatches(id);
            var playerValues = _playerStatisticService.TGetTeamsWithStatistics(id);
            foreach (var item in playerValues)
            {

                await GenerateSignedUrl(item.Player);
            }
            ViewBag.players = playerValues;
            ViewBag.lastMatches = lastMatches;
            await GenerateSignedUrl(team);
            return View(team);
        }
        public async Task GenerateSignedUrl(Player p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
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
