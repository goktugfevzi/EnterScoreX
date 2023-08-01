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

        public _MatchTodayPartial(IMatchService matchService, ICloudStorageService cloudStorageService)
        {
            _matchService = matchService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = (int)TempData["id"];
            var value = _matchService.TGetMatchWithAllDetailsByID(id);
            await GenerateSignedUrl(value.AwayTeam);
            await GenerateSignedUrl(value.HomeTeam);
            await GenerateSignedUrl(value.Stadium);
            return View(value);
        }
        public async Task GenerateSignedUrl(Team p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
        public async Task GenerateSignedUrl(Stadium p)
        {
            if (!string.IsNullOrWhiteSpace(p.SavedFileName))
            {
                p.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(p.SavedFileName);
            }
        }
    }
}
