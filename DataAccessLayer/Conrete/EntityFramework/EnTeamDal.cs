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
    public class EnTeamDal : GenericRepository<Team>, ITeamDal
    {
        public List<Team> GetTeamsWithCoach()
        {
            using var context = new EnterScoreXContext();
            return context.Teams.Include(x => x.Coach).ToList();
        }
     

    }
}
