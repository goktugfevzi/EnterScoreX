using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EnterScore.Services;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace EnterScore.ViewComponents.Fixture
{

    public class _FixturePartial : ViewComponent
    {
        private readonly IFixtureService _fixtureService;
        private readonly ICloudStorageService _cloudStorageService;

        public _FixturePartial(IFixtureService fixtureService, ICloudStorageService cloudStorageService)
        {
            _fixtureService = fixtureService;
            _cloudStorageService = cloudStorageService;
        }


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            var pageResults = _fixtureService.TGetFixtureWithTeamsGroupByWeek();

            foreach (var value in pageResults[id - 1])
            {
                await GenerateSignedUrl(value.HomeTeam);
                await GenerateSignedUrl(value.AwayTeam);
            }
            ViewBag.TotalPages = pageResults.Count;
            ViewBag.CurrentPage = id;
            return View(pageResults[id - 1]);
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