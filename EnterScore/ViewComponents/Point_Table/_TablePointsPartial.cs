using BusinessLayer.Abstract;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EnterScore.ViewComponents.Point_Table
{
    public class _TablePointsPartial : ViewComponent
    {
        private readonly ICloudStorageService _cloudStorageService;
        private readonly ITeamStatisticService _teamStatisticService;
        private readonly ITeamService _teamService;

        public _TablePointsPartial(ICloudStorageService cloudStorageService, ITeamStatisticService metricService, ITeamService teamService)
        {
            _cloudStorageService = cloudStorageService;
            _teamStatisticService = metricService;
            _teamService = teamService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _teamStatisticService.TGetTeamStatisticWithTeams();
            foreach (var value in values)
            {
                await GenerateSignedUrl(value.Team);
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
