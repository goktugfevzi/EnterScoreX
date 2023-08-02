using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Result
{
    public class _MatchTodayPartial : ViewComponent
    {
        private readonly IMatchService _matchService;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly IPlayerService _playerService;

        public _MatchTodayPartial(IMatchService matchService, ICloudStorageService cloudStorageService, IPlayerService playerService)
        {
            _matchService = matchService;
            _cloudStorageService = cloudStorageService;
            _playerService = playerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = (int)TempData["id"];
            var value = _matchService.TGetMatchWithAllDetailsByID(id);
            List<Player> players = new List<Player>();
            foreach (var item in value.Goals)
            {
                var player = _playerService.TGetById(item.PlayerID);
                players.Add(player);
            }
            TempData["players"] = players;
            await GenerateSignedUrl(value.AwayTeam);
            await GenerateSignedUrl(value.HomeTeam);
            return View(value);
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
