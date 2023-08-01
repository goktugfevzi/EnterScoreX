using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FixtureController : Controller
    {
        private readonly IFixtureService _fixtureService;
        private readonly ITeamService _teamService;
        private readonly EnterScoreXContext _context;

        public FixtureController(IFixtureService fixtureService, ITeamService teamService, EnterScoreXContext enterScoreXContext)
        {
            _fixtureService = fixtureService;
            _teamService = teamService;
            _context = enterScoreXContext;
        }

        public IActionResult Index()
        {
            var values = _fixtureService.TGetFixtureWithTeams();
            return View(values);
        }

        public IActionResult DeleteFixture()
        {

            // Delete records from Goals table.
            var goals = _context.Goals.ToList();
            _context.Goals.RemoveRange(goals);
            _context.SaveChanges();
            // Delete records from TeamStatistics table.
            var teamStatistics = _context.TeamStatistics.ToList();
            _context.TeamStatistics.RemoveRange(teamStatistics);
            _context.SaveChanges();

            // Delete records from PlayerStatistics table.
            var playerStatistics = _context.PlayerStatistics.ToList();
            _context.PlayerStatistics.RemoveRange(playerStatistics);
            _context.SaveChanges();

            // Delete records from Matches table.
            _context.Database.ExecuteSqlRaw("DELETE FROM dbo.Matches DBCC CHECKIDENT ('DbEnterScoreX.dbo.Matches', RESEED, 0)");
            _context.Database.ExecuteSqlRaw("DELETE FROM dbo.Fixtures DBCC CHECKIDENT ('DbEnterScoreX.dbo.Fixtures', RESEED, 0)");

            return RedirectToAction("Fixture", "Admin");
        }

        [HttpGet]
        public IActionResult CreateFixture()
        {
            Fixture fixture = new Fixture();
            var teams = _teamService.TGetListAll();
            var weeks = (teams.Count - 1);

            for (int i = 1; i <= weeks; i++)
            {
                fixture.Week = i;

                for (int j = 0; j < (weeks + 1) / 2; j++)
                {
                    fixture.HomeTeamID = teams[j].TeamID;
                    fixture.AwayTeamID = teams[weeks - j].TeamID;
                    fixture.WeekCompleted = false;
                    fixture.FixtureID = 0;
                    fixture.SeasonID = 1;
                    _fixtureService.TInsert(fixture);
                }

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
