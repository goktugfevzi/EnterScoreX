﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace EnterScore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IFixtureService _fixtureService;
        private readonly ITeamService _teamService;
        private readonly IGoalService _goalService;
        private readonly IPlayerService _playerService;
        private readonly IRefereeService _refereeService;

        public MatchController(IMatchService matchService, IFixtureService fixtureService, ITeamService teamService, IGoalService goalService, IPlayerService playerService, IRefereeService refereeService)
        {
            _matchService = matchService;
            _fixtureService = fixtureService;
            _teamService = teamService;
            _goalService = goalService;
            _playerService = playerService;
            _refereeService = refereeService;
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

        private void GoalSave(int goalCount, int forTeamID, int againstTeamID, int matchID)
        {
            var players = _playerService.TGetListAll();
            List<Player> teamPlayers = players.Where(player => player.TeamID == forTeamID).ToList();
            var random = new Random();
            for (int i = 0; i < goalCount; i++)
            {
                Goal goal = new Goal
                {
                    GoalTime = random.Next(5, 90),
                    PlayerID = teamPlayers[random.Next(0, teamPlayers.Count)].PlayerID,
                    GoalForTeamID = forTeamID,
                    GoalAgainstTeamID = againstTeamID,
                    MatchID = matchID
                };
                _goalService.TInsert(goal);
            }
        }
        private void PlayMatchesForWeek(List<Fixture> weekFixtures)
        {
            var referees = _refereeService.TGetListAll();
            var random = new Random();
            foreach (var fixture in weekFixtures)
            {

                int homeTeamGoals = random.Next(0, 5);
                int awayTeamGoals = random.Next(0, 5);


                int homeTeamShotsOnTarget = random.Next(homeTeamGoals, homeTeamGoals + 5);
                int awayTeamShotsOnTarget = random.Next(awayTeamGoals, awayTeamGoals + 5);

                int homeTeamShots = random.Next(homeTeamShotsOnTarget, homeTeamShotsOnTarget + 4);
                int awayTeamShots = random.Next(awayTeamShotsOnTarget, awayTeamShotsOnTarget + 4);

                int homeTeamPassSuccess;
                int awayTeamPassSuccess;
                if (homeTeamGoals > awayTeamGoals)
                {
                    homeTeamPassSuccess = random.Next(52, 63);
                    awayTeamPassSuccess = 100 - homeTeamPassSuccess;
                }
                else if (homeTeamGoals < awayTeamGoals)
                {
                    awayTeamPassSuccess = random.Next(52, 63);
                    homeTeamPassSuccess = 100 - awayTeamPassSuccess;
                }
                else
                {
                    homeTeamPassSuccess = random.Next(46, 54);
                    awayTeamPassSuccess = 100 - homeTeamPassSuccess;

                }

                int homeTeamAerialDualSuccess;
                int awayTeamAerialDualSuccess;
                if (homeTeamPassSuccess > awayTeamPassSuccess)
                {
                    homeTeamAerialDualSuccess = random.Next(55, 67);
                    awayTeamAerialDualSuccess = 100 - homeTeamAerialDualSuccess;
                }
                else if (homeTeamPassSuccess < awayTeamPassSuccess)
                {
                    awayTeamAerialDualSuccess = random.Next(55, 67);
                    homeTeamAerialDualSuccess = 100 - awayTeamAerialDualSuccess;
                }
                else
                {
                    homeTeamAerialDualSuccess = random.Next(48, 55);
                    awayTeamAerialDualSuccess = 100 - homeTeamAerialDualSuccess;
                }

                Match match = new Match
                {
                    HomeTeamID = fixture.HomeTeamID,
                    AwayTeamID = fixture.AwayTeamID,
                    FixtureID = fixture.FixtureID,
                    StadiumID = _teamService.TGetById(fixture.HomeTeamID).StadiumID,
                    RefereeID = referees[random.Next(0, 5)].RefereeID,
                    MatchID = 0,//IDENTITY HATASI FIXTUREDE ALDIĞIMLA AYNI
                    HomeTeamGoals = homeTeamGoals,
                    AwayTeamGoals = awayTeamGoals,
                    HomeTeamShots = homeTeamShots,
                    AwayTeamShots = awayTeamShots,
                    HomeTeamShotsOnTarget = homeTeamShotsOnTarget,
                    AwayTeamShotsOnTarget = awayTeamShotsOnTarget,
                    HomeTeamPassSuccess = homeTeamPassSuccess,
                    AwayTeamPassSuccess = awayTeamPassSuccess,
                    HomeTeamFoulCount = random.Next(1, 10),
                    AwayTeamFoulCount = random.Next(1, 10),
                    HomeTeamAirealDualSuccess = homeTeamAerialDualSuccess,
                    AwayTeamAirealDualSuccess = awayTeamAerialDualSuccess,
                };
                _matchService.TInsert(match);
                GoalSave(homeTeamGoals, fixture.HomeTeamID, fixture.AwayTeamID, match.MatchID);
                GoalSave(awayTeamGoals, fixture.AwayTeamID, fixture.HomeTeamID, match.MatchID);
            }

            foreach (var fixture in weekFixtures)
            {
                fixture.WeekCompleted = true;
                _fixtureService.TUpdate(fixture);
            }
        }
    }
}
