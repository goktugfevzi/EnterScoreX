using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _TablePointsPartial : ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly ICloudStorageService _cloudStorageService;

        public _TablePointsPartial(ITeamService teamService, ICloudStorageService cloudStorageService)
        {
            _teamService = teamService;
            _cloudStorageService = cloudStorageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _teamService.TGetTeamsWithStatistics();
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
