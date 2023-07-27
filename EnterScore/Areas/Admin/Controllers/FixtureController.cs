using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FixtureController : Controller
    {
        private readonly IFixtureService _fixtureService;
        private readonly ITeamService _teamService;

        public FixtureController(IFixtureService fixtureService, ITeamService teamService)
        {
            _fixtureService = fixtureService;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _fixtureService.TGetFixtureWithTeams();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFixture()
        {
            Fixture fixture = new Fixture();
            var teams = _teamService.TGetListAll();
            var weeks = (teams.Count - 1);
            // Eşleşmeleri oluştur
            for (int i = 1; i <= weeks; i++)
            {
                fixture.Week = i;

                for (int j = 0; j < (weeks + 1) / 2; j++)
                {
                    fixture.HomeTeamID = teams[j].TeamID;
                    fixture.AwayTeamID = teams[weeks - j].TeamID;
                    fixture.WeekCompleted = false;
                    //fixture.StadiumID = teams[j].StadiumID;
                    fixture.FixtureID = 0;
                    fixture.SeasonID = 1;
                    _fixtureService.TInsert(fixture);
                }

                // Takımları dairesel olarak değiştir
                var lastTeam = teams[weeks];
                for (int k = weeks; k > 1; k--)
                {
                    teams[k] = teams[k - 1];
                }
                teams[1] = lastTeam;
            }

            // İKİNCİ SEZON ATAMASI YAPMA KISMI
            var previousSeasonFixtures = _fixtureService.TGetListAll();
            for (int i = 1; i <= weeks; i++)
            {
                fixture.Week = i + weeks; // weeksi üstüne eklememizin sebebi ikinci sezonun haftası belli olsun diye 

                int fixtureIndex = (i - 1) * (teams.Count / 2);
                for (int j = 0; j < teams.Count / 2; j++)
                {
                    fixture.HomeTeamID = previousSeasonFixtures[fixtureIndex].AwayTeamID;
                    fixture.AwayTeamID = previousSeasonFixtures[fixtureIndex].HomeTeamID;
                    //fixture.StadiumID = fixture.HomeTeam.StadiumID;
                    fixture.WeekCompleted = false;
                    fixture.SeasonID = 2;
                    fixture.FixtureID = 0; // table 'Fixtures' when IDENTITY_INSERT is set to OFF.
                    _fixtureService.TInsert(fixture);
                    fixtureIndex++;
                }
            }
            return RedirectToAction("Fixture", "Admin");
        }
    }
}
