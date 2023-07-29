using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EnterScore.ViewComponents.ClubsList
{
    public class _ClubsListPartial : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly ICloudStorageService _cloudStorageService;

        public _ClubsListPartial(ITeamService teamService, ICloudStorageService cloudStorageService)
        {
            _teamService = teamService;
            _cloudStorageService = cloudStorageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _teamService.TGetListAll();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value);
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
