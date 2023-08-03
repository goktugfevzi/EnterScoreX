using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnTeamStatisticDal : GenericRepository<TeamStatistic>, ITeamStatisticDal
    {
        public List<TeamStatistic> GetTeamStatisticWithTeams()
        {
            using var context = new EnterScoreXContext();
            return context.TeamStatistics
                          .Include(x => x.Team)
                          .OrderByDescending(x => x.Points)
                          .ToList();
        }
    }
}
