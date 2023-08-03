using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnTeamDal : GenericRepository<Team>, ITeamDal
    {
        public List<Team> GetTeamsWithCoach()
        {
            using var context = new EnterScoreXContext();
            return context.Teams.Include(x => x.Coach).ToList();
        }
        public List<Team> GetTeamsWithStatistics()
        {
            using var context = new EnterScoreXContext();
            return context.Teams.Include(x => x.Statistics).ToList();
        }
        public Team GetTeamWithCoachById(int id)
        {
            using var context = new EnterScoreXContext();
            var team = context.Teams
                              .Include(x => x.Coach)
                              .Include(x => x.Statistics)
                              .Include(x => x.Stadium)
                              .FirstOrDefault(x => x.TeamID == id);
            return team;
        }
    }
}