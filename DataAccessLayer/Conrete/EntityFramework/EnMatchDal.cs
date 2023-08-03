using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnMatchDal : GenericRepository<Match>, IMatchDal
    {
        public List<Match> GetMatchWithTeams()
        {
            using var context = new EnterScoreXContext();
            return context.Matches
                          .Include(x => x.HomeTeam)
                          .Include(x => x.AwayTeam)
                          .Include(x => x.HomeTeam.Coach)
                          .Include(x => x.AwayTeam.Coach).ToList();
        }
        public List<Match> GetMatchWithAllDetails()
        {
            using var context = new EnterScoreXContext();
            return context.Matches
                          .Include(x => x.HomeTeam)
                          .Include(x => x.AwayTeam)
                          .Include(x => x.HomeTeam.Coach)
                          .Include(x => x.AwayTeam.Coach)
                          .Include(x => x.HomeTeam.Stadium)
                          .Include(x => x.Referee)
                          .Include(x => x.Fixture).ToList();
        }
        public Match GetMatchWithTeamByID(int MatchID)
        {
            using var context = new EnterScoreXContext();
            return context.Matches
                          .Include(x => x.HomeTeam)
                          .Include(x => x.AwayTeam)
                          .Include(x => x.Goals)
                          .Include(x => x.HomeTeam.Coach)
                          .Include(x => x.AwayTeam.Coach)
                          .FirstOrDefault(x => x.MatchID == MatchID);
        }
        public Match GetMatchWithAllDetailsByID(int MatchID)
        {
            using var context = new EnterScoreXContext();
            var match = context.Matches
                              .Include(x => x.HomeTeam)
                              .Include(x => x.AwayTeam)
                              .Include(x => x.Goals)
                              .Include(x => x.HomeTeam.Coach)
                              .Include(x => x.AwayTeam.Coach)
                              .Include(x => x.HomeTeam.Stadium)
                              .Include(x => x.Referee)
                              .Include(x => x.Fixture)
                              .FirstOrDefault(x => x.MatchID == MatchID);

            match?.Goals.OrderBy(goal => goal.GoalTime);

            return match;
        }

        public List<Match> GetTeamLastMatches(int teamID)
        {
            using var context = new EnterScoreXContext();
            var lastMatches = context.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .Include(x => x.Fixture)
                .Where(x => x.HomeTeamID == teamID || x.AwayTeamID == teamID)
                .OrderByDescending(x => x.MatchID)
                .Take(5)
                .ToList();

            return lastMatches;
        }





    }
}
