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
    public class EnMatchDal : GenericRepository<Match>, IMatchDal
    {
        public List<Match> GetMatchWithTeams()
        {

            using var context = new EnterScoreXContext();
            return context.Matches
                          .Include(x => x.HomeTeam)
                          .Include(x => x.AwayTeam)

                          .ToList();
        }
    }
}

