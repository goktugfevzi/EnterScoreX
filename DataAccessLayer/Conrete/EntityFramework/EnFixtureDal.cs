using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class EnFixtureDal : GenericRepository<Fixture>, IFixtureDal
    {
        public List<Fixture> GetFixtureWithTeams()
        {
            using var context = new EnterScoreXContext();
            return context.Fixtures
                          .Include(x => x.HomeTeam)
                          .Include(x => x.AwayTeam)
                          .ToList();
        }
    }
}
