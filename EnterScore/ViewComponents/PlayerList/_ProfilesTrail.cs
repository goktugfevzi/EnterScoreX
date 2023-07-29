using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EnterScore.ViewComponents.PlayerList
{
    public class _ProfilesTrail : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        private readonly ICloudStorageService _cloudStorageService;

        public _ProfilesTrail(IPlayerService playerService, ITeamService teamService, ICloudStorageService cloudStorageService)
        {
            _playerService = playerService;
            _teamService = teamService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = _playerService.TGetPlayersByTeamID(id);
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);
            }
            return View(values);
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
