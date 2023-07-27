using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IFixtureService _fixtureService;
        private readonly ITeamService _teamService;
        private int _lastPlayedWeek;

        public MatchController(IMatchService matchService, IFixtureService fixtureService, ITeamService teamService)
        {
            _matchService = matchService;
            _fixtureService = fixtureService;
            _lastPlayedWeek = 0;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PlayTheWeek()
        {
            var fixtures = _fixtureService.TGetListAll();
            var nextUnplayedWeek = FindNextUnplayedWeek(fixtures);

            if (nextUnplayedWeek != -1)
            {
                var nextWeekFixtures = fixtures.Where(f => f.Week == nextUnplayedWeek).ToList();
                PlayMatchesForWeek(nextWeekFixtures);
            }

            return RedirectToAction("Fixture", "Admin");
        }

        private int FindNextUnplayedWeek(List<Fixture> fixtures)
        {
            foreach (var fixture in fixtures)
            {
                if (!fixture.WeekCompleted)
                {
                    return fixture.Week;
                }
            }

            return -1; // Tüm haftalar oynanmışsa -1  döndürcem
        }
        private void PlayMatchesForWeek(List<Fixture> weekFixtures)
        {
            var random = new Random();
            foreach (var fixture in weekFixtures)
            {
                Match match = new Match
                {
                    HomeTeamID = fixture.HomeTeamID,
                    AwayTeamID = fixture.AwayTeamID,
                    StadiumID = _teamService.TGetById(fixture.HomeTeamID).StadiumID,
                    RefereeID = random.Next(0, 5),
                    HomeTeamShots = random.Next(0, 15),
                    AwayTeamShots = random.Next(0, 15),
                    HomeTeamShotsOnTarget = random.Next(0, 10),
                    AwayTeamShotsOnTarget = random.Next(0, 10),
                    HomeTeamPassSuccess = random.Next(0, 100),
                    AwayTeamPassSuccess = random.Next(0, 100),
                    HomeTeamFoulCount = random.Next(0, 20),
                    AwayTeamFoulCount = random.Next(0, 20),
                    HomeTeamAirealDualSuccess = random.Next(0, 100),
                    AwayTeamAirealDualSuccess = random.Next(0, 100),
                };

                _matchService.TInsert(match);
            }

            foreach (var fixture in weekFixtures)
            {
                fixture.WeekCompleted = true;
                _fixtureService.TUpdate(fixture);
            }
        }
    }
}
