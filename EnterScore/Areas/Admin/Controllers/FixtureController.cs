using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

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
            var values = _fixtureService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFixture()
        {
            Fixture fixture = new Fixture();
            var teams = _teamService.TGetListAll();
            var weeks = (teams.Count - 1) * 2;

            for (int i = 1; i <= weeks; i++)
            {
                fixture.Week = i;
                List<Team> shuffledTeams = ShuffleTeams(teams);

                for (int j = 0; j < teams.Count / 2; j++)
                {
                    fixture.HomeTeamID = shuffledTeams[j].TeamID;
                    fixture.AwayTeamID = shuffledTeams[teams.Count - 1 - j].TeamID;
                    fixture.WeekCompleted = false;
                    fixture.FixtureID = 0;
                    _fixtureService.TInsert(fixture);
                }
            }
            return RedirectToAction("Fixture", "Admin");
        }
        private List<Team> ShuffleTeams(List<Team> teams)
        {
            Random rand = new Random();
            int n = teams.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Team value = teams[k];
                teams[k] = teams[n];
                teams[n] = value;
            }
            return teams;
        }

    }
}
