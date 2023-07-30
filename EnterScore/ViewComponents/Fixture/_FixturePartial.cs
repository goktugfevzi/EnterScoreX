using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EnterScore.ViewComponents.Fixture
{

    public class _FixturePartial : ViewComponent
    {
        private readonly IMatchService _matchService;
        private readonly ICloudStorageService _cloudStorageService;

        public _FixturePartial(IMatchService matchService, ICloudStorageService cloudStorageService)
        {
            _matchService = matchService;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _matchService.TGetMatchWithTeams();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value.HomeTeam);
                await GenerateSignedUrl(value.AwayTeam);
            }
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
